using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Concurrent;
using System.IO;
using ExifLib;

using System.Collections.ObjectModel;

namespace IImages
{
    public partial class Form1 : Form
    {

        List<image> ajout = new List<image>();
        List<image> ajoutSelection = new List<image>();

        List<image> search = new List<image>();
        List<image> searchSelection = new List<image>();
        
        //Accès à la base de données
        MongoClient client;
        MongoDB.Driver.IMongoDatabase database;
        MongoDB.Driver.IMongoCollection<BsonDocument> iimages;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("iimages");
            iimages = database.GetCollection<BsonDocument>("iimages");
            long x = await iimages.CountAsync(new BsonDocument());
            label5.Text = x.ToString() + " éléments dans le catalogue";

            tabControl1.SelectedIndex = 1;
            labelAjoutDate.Text = "";
            labelAjoutNom.Text = "";

            status.Text = "Connecté";

            //on affiche déja quelques images venant de la base de données
            var filter = new BsonDocument();
            var cursor = await iimages.FindAsync(filter);

            await cursor.MoveNextAsync();
            
                var batch = cursor.Current;
                foreach (var document in batch)
                {
                    search.Add(MongoDB.Bson.Serialization.BsonSerializer.Deserialize<image>(document));
                }
            
            foreach (image im in search)
            {
                im.generate_thumb();
                imageListSearch.Images.Add(im.path, im.thumb);
                listViewSearch.Items.Add(im.path, Path.GetFileName(im.path), im.path);
            }
        }

        #region Ajout

        private void searchParcourir_Click(object sender, EventArgs e)
        {
            
            ajout.Clear();
            imageListajout.Images.Clear();
            listViewAjout.Clear();

            int PictureWidth = 100;
            string FolderName = "C:\test";
            
            FolderBrowserDialog browser = new FolderBrowserDialog();
            browser.SelectedPath = FolderName;
            DialogResult res = browser.ShowDialog();

            if (res == System.Windows.Forms.DialogResult.OK)
            {
                FolderName = browser.SelectedPath;
                pictureBox1.Visible = true;
                Task<IEnumerable<image>>.Factory.StartNew(
                    () =>
                    {
                        // chargement des vignettes dans un ConcurrentBag
                        var images = new List<image>();
                        Parallel.ForEach(Directory.GetFiles(FolderName, "*.jpg"),
                                         fileName =>
                                         {
                                             // On charge l'image
                                             Image img = new Bitmap(fileName);

                                             //création de l'objet image correspondant
                                             var newImg = new image(fileName);
                                             
                                             //crétation de la vignette
                                             newImg.thumb = img.GetThumbnailImage(PictureWidth,PictureWidth,null,IntPtr.Zero);
                                             
                                             //lecture de la date de prise de vue de l'image
                                             using (ExifReader reader = new ExifReader(fileName))
                                             {
                                                 // Extract the tag data using the ExifTags enumeration
                                                 DateTime datePictureTaken;
                                                 if (reader.GetTagValue<DateTime>(ExifTags.DateTimeDigitized, out datePictureTaken))
                                                 {
                                                     // Do whatever is required with the extracted information
                                                     newImg.date = datePictureTaken;
                                                     newImg.generate_document();
                                                 }
                                             }
                                             ajout.Add(newImg);
                                             images.Add(newImg);

                                             img.Dispose();
                                         });

                        return images;
                    }).ContinueWith(
                            task =>
                            {
                                //ajout des miniatures aux controles de l'interface et affichage
                                foreach (var image in task.Result)
                                {
                                    imageListajout.Images.Add(image.path, image.thumb);
                                    listViewAjout.Items.Add(image.path, Path.GetFileName(image.path), image.path);
                                }
                                pictureBox1.Visible = false;
                                status.Text = ajout.Count() + " images détectées";
                            },
                            TaskScheduler.FromCurrentSynchronizationContext());
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ajoutSelection.Count != 0)
            {
                foreach (image im in ajoutSelection)
                {
                    var tmp = ajout.Find(i => i.path == im.path);

                    tmp.rating = im.rating;
                    tmp.tags = im.tags;
                    tmp.personnes = im.personnes;
                }

            }
            foreach (image im in ajout)
            {
                im.generate_document();
                //copie des fichiers source dans le repertoire de l'application
                string outfilename = Path.GetFileName(im.path);
                string sourcefolder = Path.GetDirectoryName(im.path);
                string outfolder = "C:\\data\\img\\" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + "\\";
                if (!System.IO.Directory.Exists(outfolder))
                {
                    System.IO.Directory.CreateDirectory(outfolder);
                }
                System.IO.File.Copy(im.path, outfolder + outfilename, true);
                im.path = outfolder + outfilename;
                im.generate_document();
                iimages.InsertOneAsync(im.doc);
            }
            status.Text = "Envoyés !";
            ajoutSelection.Clear();
            ajout.Clear();
            imageListajout.Images.Clear();
            listViewAjout.Items.Clear();
        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelAdd_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listViewAjout_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
            
        }

        private void labelAjoutDate_Click(object sender, EventArgs e)
        {

        }

        private void listViewAjout_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            //enregistrement des données de ajoutelection dans selection
            if (ajoutSelection.Count != 0)
            {
                foreach(image im in ajoutSelection)
                {
                    var tmp = ajout.Find(i => i.path == im.path);
                    
                    tmp.rating = im.rating;
                    tmp.tags = im.tags;
                    tmp.personnes = im.personnes;
                }
                
            }

            //mise en place de la nouvelle sélection
            var selection = listViewAjout.SelectedItems;
            if (selection.Count == 1)
            {
                //liste temporaire de selection
                List<string> keys = new List<string>();
                ajoutSelection.Clear();
                foreach (ListViewItem item in selection)
                {
                    ajoutSelection.Add(ajout.Find(i => i.path == item.ImageKey));
                }


                //rafraichissement de l'interface
                labelAjoutNom.Text = ajoutSelection.First().path;
                labelAjoutDate.Text = ajoutSelection.First().date.ToString();
                numericUpDown1.Value = ajoutSelection.First().rating;

                richTextBoxAjoutPersonnes.Lines = new string[] {""};
                richTextBoxAjoutTags.Lines = new string[] { "" };

              
                int count = 0;
                foreach(string str in ajoutSelection.First().tags)
                {
                    richTextBoxAjoutTags.AppendText(str + "\n");
                    count += 1;
                }
                count = 0;
                foreach (string str in ajoutSelection.First().personnes)
                {
                    richTextBoxAjoutPersonnes.Lines[count] = str;
                    count++;
                }

                numericUpDown1.Enabled = true;
                richTextBoxAjoutTags.Enabled = true;
                richTextBoxAjoutPersonnes.Enabled = true;

            }
            else if (selection.Count > 1)
            {
                List<string> keys = new List<string>();
                ajoutSelection.Clear();
                foreach (ListViewItem item in selection)
                {
                    ajoutSelection.Add(ajout.Find(i => i.path == item.ImageKey));
                }

                labelAjoutNom.Text = "Plusieurs valeurs";
                labelAjoutDate.Text = "Plusieurs valeurs";
                numericUpDown1.Enabled = true;
                richTextBoxAjoutTags.Enabled = true;
                richTextBoxAjoutPersonnes.Enabled = true;
               
            }
            else
            {
                ajoutSelection.Clear();
                labelAjoutDate.Text = "";
                labelAjoutNom.Text = "";
                numericUpDown1.Enabled = false;
                richTextBoxAjoutTags.Enabled = false;
                richTextBoxAjoutPersonnes.Enabled = false;
            }
        }

        private void buttonAjoutSelectAll_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in listViewAjout.Items)
            {
                item.Selected = true;
            }
            listViewAjout.Select();
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (ListViewItem item in listViewAjout.Items)
            {
                item.Selected = !item.Selected;
            }
            listViewAjout.Select();
        }

        private void buttonAjoutSuppr_Click(object sender, EventArgs e)
        {
            foreach (image im in ajoutSelection)
            {
                ajout.Remove(im);
            }

            foreach (ListViewItem item in listViewAjout.Items)
            {
                if (item.Selected) { listViewAjout.Items.Remove(item); }
            }
            status.Text = ajout.Count + " images détectées";
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (ajoutSelection.Count != 0)
            {
                foreach (image im in ajoutSelection)
                {
                    im.rating = (int)numericUpDown1.Value;
                }
            }
        }


        private void richTextBoxAjoutTags_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void richTextBoxAjoutTags_Validating(object sender, CancelEventArgs e)
        {
            foreach (image item in ajoutSelection)
            {
                item.tags.Clear();
                int length = richTextBoxAjoutTags.Lines.Length;
                for (int i = 0; i < length; i++)
                {
                    item.tags.Add(richTextBoxAjoutTags.Lines[i]);
                }
            }
        }

        #endregion

        


        #region Search

        private void listViewSearch_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            var selection = listViewSearch.SelectedItems;
            if (selection.Count == 1)
            {
                searchSelection.Clear();
                foreach (ListViewItem item in selection)
                {
                    searchSelection.Add(search.Find(i => i.path == item.ImageKey));
                }
            }
            if (pictureBox2.Image != null)
            {
                pictureBox2.Image.Dispose();
            }
            pictureBox2.Image = Image.FromFile(searchSelection.First().path);
        }



        #endregion

        private void listViewSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            var selection = listViewSearch.SelectedItems;
            if (selection.Count == 1)
            {
                searchSelection.Clear();
                foreach (ListViewItem item in selection)
                {
                    searchSelection.Add(search.Find(i => i.path == item.ImageKey));
                }
            }
           
            if (pictureBox2.Image != null)
            {
                pictureBox2.Image.Dispose();
            }
            pictureBox2.Image = Image.FromFile(searchSelection.First().path);
             * */
        }
        

    }
}
