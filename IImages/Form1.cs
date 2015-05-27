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
        //Variables Ajout
        List<image> ajout = new List<image>();
        List<image> ajoutSelection = new List<image>();

        //Variables Search
        List<image> search = new List<image>();
        List<image> searchSelection = new List<image>();
        List<tagsElt> listTags = new List<tagsElt>();
        List<tagsElt> listPersonnes = new List<tagsElt>();
        List<bookmark> listBookmarks = new List<bookmark>();

        //Accès à la base de données
        MongoClient client;
        MongoDB.Driver.IMongoDatabase database;
        MongoDB.Driver.IMongoCollection<BsonDocument> iimages;

        Bitmap logoIIMAGES;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            labelAjoutDate.Text = "";
            labelAjoutNom.Text = "";



            status.Text = "Connecté";

            logoIIMAGES = new Bitmap("iimages.png");
            //refresh();
        }

        public async void refreshBookmarks()
        {
            listBookmarks.Clear();

            client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("iimages");
            MongoDB.Driver.IMongoCollection<BsonDocument> bookmarks = database.GetCollection<BsonDocument>("bookmarks");

            var filter = new BsonDocument();

            //requete
            var cursor = await bookmarks.FindAsync(filter);

            //traitement des résultats
            while (await cursor.MoveNextAsync())
            {
                var batch = cursor.Current;
                foreach (var book in batch)
                {
                    listBookmarks.Add(MongoDB.Bson.Serialization.BsonSerializer.Deserialize<bookmark>(book));
                }
            }

            foreach (var book in listBookmarks)
            {
                comboBoxBookmarks.Items.Add(book.name);
            }
        }

        public async void refreshTags()
        {

            var tmpTags = await iimages.Find(new BsonDocument()).Project(Builders<BsonDocument>.Projection.Include("tags")).ToListAsync();

            listTags.Clear();
            foreach (var document in tmpTags)
            {
                List<string> newTag = new List<string>();
                newTag.AddRange((document["tags"].AsBsonArray.Select(p => p.AsString).ToList()));
                if (newTag.Count() != 0)
                {
                    foreach (string s in newTag)
                        if (listTags.FindAll(p => p.tag == s).Count() == 0)
                        {
                            var tmp = new tagsElt();
                            tmp.tag = s;
                            tmp.count = 1;
                            listTags.Add(tmp);
                        }
                        else
                        {
                            listTags.FindAll(p => p.tag == s).First().count += 1;
                        }
                }
            }
            listTags = listTags.OrderBy(t => t.count).ToList();
            listTags.Reverse();

            //affichage des tags
            comboBoxTags.Items.Clear();
            foreach (tagsElt tag in listTags)
            {
                comboBoxTags.Items.Add(tag.tag + " - " + tag.count + " éléments");
            }
        }

        public async void refreshPersonnes()
        {

            var tmpPersonnes = await iimages.Find(new BsonDocument()).Project(Builders<BsonDocument>.Projection.Include("personnes")).ToListAsync();

            listPersonnes.Clear();
            foreach (var document in tmpPersonnes)
            {
                List<string> newPersonnes = new List<string>();
                newPersonnes.AddRange((document["personnes"].AsBsonArray.Select(p => p.AsString).ToList()));
                if (newPersonnes.Count() != 0)
                {
                    foreach (string s in newPersonnes)
                        if (listPersonnes.FindAll(p => p.tag == s).Count() == 0)
                        {
                            var tmp = new tagsElt();
                            tmp.tag = s;
                            tmp.count = 1;
                            listPersonnes.Add(tmp);
                        }
                        else
                        {
                            listPersonnes.FindAll(p => p.tag == s).First().count += 1;
                        }
                }
            }
            listPersonnes = listPersonnes.OrderBy(t => t.count).ToList();
            listPersonnes.Reverse();

            //affichage des tags
            comboBoxPersonnes.Items.Clear();
            foreach (tagsElt per in listPersonnes)
            {
                comboBoxPersonnes.Items.Add(per.tag + " - " + per.count + " éléments");
            }
        }

        public async void refresh()
        {
            //Cleanning
            imageListSearch.Images.Clear();
            listViewSearch.Items.Clear();
            search.Clear();
            searchSelection.Clear();
            pictureBox2.Image = null;
            pictureBoxHist.Image = null;
            listViewSearch.SelectedItems.Clear();
            disableEditing();

            client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("iimages");
            iimages = database.GetCollection<BsonDocument>("iimages");

            //comptage des éléements de la base
            long x = await iimages.CountAsync(new BsonDocument());
            label5.Text = x.ToString() + " éléments dans le catalogue";


            //liste des tags dans la base
            refreshTags();

            //listes des personnes dans la base
            refreshPersonnes();

            //creation du filtre
            var builder = Builders<BsonDocument>.Filter;
            //var filter = builder.Eq("rating",(int)numericUpDownSearch.Value);
            //filter = builder.And(filter, builder.Gt("rating",(int)numericUpDownSearch.Value));
            //var filter = builder.Eq("rating", (int)numericUpDownSearch.Value);
            //analyse du champ de recherche
            var words = textBoxSearch.Text.Split(' ');
            List<int> dates = new List<int>();
            List<string> tags = new List<string>();
            List<string> personnes =  new List<string>();
            foreach (string w in words)
            {
                //on regarde s'il y a une année
                int i;
                if (Int32.TryParse(w, out i)) 
                {
                    if ((i <2000)&&(i<2100))
                    {
                        dates.Add(i);
                    }
                }
                else
                {
                    tags.Add(w);
                    personnes.Add(w);
                }
            }
            var filterDates = new BsonArray();
            foreach (int i in dates)
            {
                filterDates.Add(new BsonInt32(i));
            }

            var filterTags = new BsonArray();
            foreach (string word in tags)
            {
                filterTags.Add(new BsonString(word));
            }

            var filterPersonnes = new BsonArray();
            foreach (string word in personnes)
            {
                filterPersonnes.Add(new BsonString(word));
            }

            var filterRatings = new BsonArray();
            if (checkBoxAbove.Checked)
            {
                for (int i = (int)numericUpDownSearch.Value ; i < 6; i++)
                {
                    filterRatings.Add(i);
                }
            }    
            else
            {
                filterRatings.Add(new BsonInt32((int)numericUpDownSearch.Value));
            }

            var filter = builder.And(builder.In("rating",filterRatings),builder.Or(builder.In("tags",filterTags),builder.In("personnes",filterPersonnes)));

            //requete
            var cursor = await iimages.FindAsync(filter);
            
            //traitement des résultats
            while (await cursor.MoveNextAsync())
            {
                var batch = cursor.Current;
                foreach (var document in batch)
                {
                    search.Add(MongoDB.Bson.Serialization.BsonSerializer.Deserialize<image>(document));
                }
            }

            //affichage des résultats
            foreach (image im in search)
            {
                im.load_thumb();
                imageListSearch.Images.Add(im.path, im.thumb);
                listViewSearch.Items.Add(im.path, Path.GetFileName(im.path), im.path);
            }
            
            label14.Text = search.Count() + " résultats";

            if (search.Count() == 0) { label14.Text = "Pas de résultats pour cette recherche"; }

        }

        #region Ajout

        private void searchParcourir_Click(object sender, EventArgs e)
        {
            
            ajout.Clear();
            imageListajout.Images.Clear();
            listViewAjout.Clear();

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
                                             //Image img = new Bitmap(fileName);

                                             //création de l'objet image correspondant
                                             var newImg = new image(fileName);
                                             
                                             //crétation de la vignette
                                             //newImg.thumb = img.GetThumbnailImage(PictureWidth,PictureWidth,null,IntPtr.Zero);
                                             
                                             //lecture de la date de prise de vue de l'image
                                             try
                                             {
                                                 using (ExifReader reader = new ExifReader(fileName))
                                                 {
                                                     // Extract the tag data using the ExifTags enumeration
                                                     if (reader != null)
                                                     {
                                                         DateTime datePictureTaken;
                                                         if (reader.GetTagValue<DateTime>(ExifTags.DateTimeDigitized, out datePictureTaken))
                                                         {
                                                             // Do whatever is required with the extracted information
                                                             newImg.date = datePictureTaken;
                                                             newImg.generate_document();
                                                         }
                                                     }
                                                 }
                                             }
                                             catch (Exception Ex)
                                             {
                                                 newImg.date = File.GetLastWriteTime(fileName);
                                                 //status.Text = Ex.ToString();
                                             }
                                             DirectoryInfo info = new DirectoryInfo(Path.GetDirectoryName(newImg.path));
                                             string currentDirectoryName = info.Name;
                                             var tags = currentDirectoryName.Split(' ');
                                             foreach (string s in tags)
                                             {
                                                 newImg.tags.Add(s);
                                             }
                                             ajout.Add(newImg);
                                             images.Add(newImg);
                                             //img.Dispose();
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
                im.path_tb = outfolder + Path.GetFileNameWithoutExtension(outfilename) + "_tb.jpg"; 
                im.Save_thumb();
                im.generate_document();
                iimages.InsertOneAsync(im.doc);
            }
            status.Text = "Envoyés !";
            ajoutSelection.Clear();
            ajout.Clear();
            imageListajout.Images.Clear();
            listViewAjout.Items.Clear();
            richTextBoxAjoutPersonnes.Enabled = false;
            richTextBoxAjoutTags.Enabled = false;
            numericUpDown1.Enabled = false;
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

                richTextBoxAjoutPersonnes.Lines = new string[] {};
                richTextBoxAjoutTags.Lines = new string[] { };

              
                int count = 0;
                foreach(string str in ajoutSelection.First().tags)
                {
                    richTextBoxAjoutTags.AppendText(str + "\n");
                    count += 1;
                }
                count = 0;
                foreach (string str in ajoutSelection.First().personnes)
                {
                    richTextBoxAjoutPersonnes.AppendText(str + "\n");
                    count += 1;
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
                    if (richTextBoxAjoutTags.Lines[i]!="") 
                        item.tags.Add(richTextBoxAjoutTags.Lines[i]);
                }
            }
        }

        private void richTextBoxAjoutPersonnes_Validating(object sender, CancelEventArgs e)
        {
            foreach (image item in ajoutSelection)
            {
                item.personnes.Clear();
                int length = richTextBoxAjoutPersonnes.Lines.Length;
                for (int i = 0; i < length; i++)
                {
                    if (richTextBoxAjoutPersonnes.Lines[i] != "") 
                        item.personnes.Add(richTextBoxAjoutPersonnes.Lines[i]);
                }
            }
        }

        //bouton annuler page ajout
        private void button3_Click(object sender, EventArgs e)
        {
            listViewAjout.Clear();
            imageListajout.Images.Clear();
            ajoutSelection.Clear();
            ajout.Clear();
        }


        #endregion

        


        #region Search

        private void listViewSearch_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            //si une photo est déja selectionnée on enregistre les modifications
            /*if (searchSelection.Count() == 1)
            {
                var tmp = search.Find(i => i.path == searchSelection.First().path);

                tmp.rating = searchSelection.First().rating;
                tmp.tags = searchSelection.First().tags;
                tmp.personnes = searchSelection.First().personnes;

                tmp.generate_document();
                var builder = Builders<BsonDocument>.Filter;
                var filter = builder.Eq("path", tmp.path);
                await iimages.ReplaceOneAsync(filter, tmp.doc);
            }*/
            
            
            


            //affiche de la nouvelle sélection
            var selection = listViewSearch.SelectedItems;
            if (selection.Count == 1)
            {
                searchSelection.Clear();
                foreach (ListViewItem item in selection)
                {
                    searchSelection.Add(search.Find(i => i.path == item.ImageKey));
                }
                
                
                //rafraichissement de l'interface
                label12.Text = Path.GetFileNameWithoutExtension(searchSelection.First().path);
                label15.Text = searchSelection.First().date.ToString();
                numericUpDownSearchEdit.Value = searchSelection.First().rating;
                richTextBoxSearchPersonnes.Lines = new string[] { "" };
                richTextBoxSearchTags.Lines = new string[] { "" };

                int count = 0;
                foreach (string str in searchSelection.First().tags)
                {
                    richTextBoxSearchTags.AppendText(str + "\n");
                    count += 1;
                }
                count = 0;
                foreach (string str in searchSelection.First().personnes)
                {
                    richTextBoxSearchPersonnes.AppendText(str + "\n");
                    count += 1;
                }

                numericUpDownSearchEdit.Enabled = true;
                richTextBoxSearchPersonnes.Enabled = true;
                richTextBoxSearchTags.Enabled = true;
                buttonSearchCopy.Enabled = true;
                buttonSearchOpen.Enabled = true;
                buttonSearchSuppr.Enabled = true;

                buttonSearchCopy.Enabled = true;
                buttonSearchOpen.Enabled = true;
                buttonSearchSuppr.Enabled = true;

                if (pictureBox2.Image != null)
                {
                    pictureBox2.Image.Dispose();
                }
                //affichage de l'image
               
                pictureBox2.Image = Image.FromFile(searchSelection.First().path);
                Bitmap bmp = new Bitmap(pictureBox2.Image);
               
                //génération de l'histogramme
                
                int[,] hist = new int[3, 256];
                for (int i = 0; i < 3; ++i)
                    for (int j = 0; j < 256; ++j)
                        hist[i, j] = 0;

                for (int i = 0; i < bmp.Width; i += 11)
                    for (int j = 0; j < bmp.Height; j += 3)
                    {
                        var col = bmp.GetPixel(i, j);
                        hist[0, col.R]++;
                        hist[1, col.G]++;
                        hist[2, col.B]++;
                    }
                
                 //generate fixed size bitmap
                const int width = 256, height = 94;
                Bitmap res = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                /*using (Graphics g = Graphics.FromImage(res))
                {
                    for (int i = 0; i < 3; ++i)
                    {
                        using (Pen p = new Pen(i == 0 ? Color.Red : i == 1 ? Color.Green : Color.Blue))
                        {
                            for (int j = 0; j < width; ++j)
                            {
                                var temp = hist[i, j];
                                if (temp < 1)
                                    temp = 1;
                                int myHeight = (int)(Math.Log(temp) * 10);
                                g.DrawLine(p, j, height, j, height - myHeight);
                            }
                        }
                    }
                }*/
                using (Graphics g = Graphics.FromImage(res))
                {
                    for (int i = 0; i < 3; ++i)
                    {
                        using (Pen p = new Pen(Color.FromArgb(0,0,0)))
                        {
                            for (int j = 0; j < width; ++j)
                            {
                                int myHeight1 = 0;
                                int myHeight2 = 0;
                                int myHeight3 = 0;

                                var tempR = hist[0, j];
                                var tempG = hist[1, j];
                                var tempB = hist[2, j];

                                if (tempR < 1) tempR = 1;
                                if (tempG < 1) tempG = 1;
                                if (tempB < 1) tempB = 1;

                                if ((tempB < tempR) && (tempB < tempG))
                                {
                                    p.Color = Color.FromArgb(64,64,64);
                                    myHeight1 = (int)(Math.Log(tempB) * 10);
                                    g.DrawLine(p, j, height, j, height - myHeight1);

                                    if (tempR < tempG)
                                    {
                                        myHeight2 = (int)(Math.Log(tempR) * 10);
                                        p.Color = Color.FromArgb(255, 255, 0);
                                        g.DrawLine(p, j, height - myHeight1, j, height - myHeight2);

                                        myHeight3 = (int)(Math.Log(tempG) * 10);
                                        p.Color = Color.FromArgb(0, 255, 0);
                                        g.DrawLine(p, j, height - myHeight2, j, height - myHeight3);
                                    }
                                    else
                                    {
                                        myHeight2 = (int)(Math.Log(tempG) * 10);
                                        p.Color = Color.FromArgb(255, 255, 0);
                                        g.DrawLine(p, j, height - myHeight1, j, height - myHeight2);

                                        myHeight3 = (int)(Math.Log(tempR) * 10);
                                        p.Color = Color.FromArgb(255, 0, 0);
                                        g.DrawLine(p, j, height - myHeight2, j, height - myHeight3);
                                    }
                                }
                                else if ((tempG < tempR) && (tempG < tempB))
                                {
                                    p.Color = Color.FromArgb(64,64,64);
                                    myHeight1 = (int)(Math.Log(tempG) * 10);
                                    g.DrawLine(p, j, height, j, height - myHeight1);

                                    if (tempR < tempB)
                                    {
                                        myHeight2 = (int)(Math.Log(tempR) * 10);
                                        p.Color = Color.FromArgb(255, 0, 255);
                                        g.DrawLine(p, j, height - myHeight1, j, height - myHeight2);

                                        myHeight3 = (int)(Math.Log(tempB) * 10);
                                        p.Color = Color.FromArgb(0, 0, 255);
                                        g.DrawLine(p, j, height - myHeight2, j, height - myHeight3);
                                    }
                                    else
                                    {
                                        myHeight2 = (int)(Math.Log(tempB) * 10);
                                        p.Color = Color.FromArgb(255, 0, 255);
                                        g.DrawLine(p, j, height - myHeight1, j, height - myHeight2);

                                        myHeight3 = (int)(Math.Log(tempR) * 10);
                                        p.Color = Color.FromArgb(255, 0, 0);
                                        g.DrawLine(p, j, height - myHeight2, j, height - myHeight3);
                                    }
                                }
                                else if ((tempR < tempG) && (tempR < tempB))
                                {
                                    p.Color = Color.FromArgb(64,64,64);
                                    myHeight1 = (int)(Math.Log(tempR) * 10);
                                    g.DrawLine(p, j, height, j, height - myHeight1);

                                    if (tempG < tempB)
                                    {
                                        myHeight2 = (int)(Math.Log(tempG) * 10);
                                        p.Color = Color.FromArgb(0, 255, 255);
                                        g.DrawLine(p, j, height - myHeight1, j, height - myHeight2);

                                        myHeight3 = (int)(Math.Log(tempB) * 10);
                                        p.Color = Color.FromArgb(0, 0, 255);
                                        g.DrawLine(p, j, height - myHeight2, j, height - myHeight3);
                                    }
                                    else
                                    {
                                        myHeight2 = (int)(Math.Log(tempB) * 10);
                                        p.Color = Color.FromArgb(0, 255, 255);
                                        g.DrawLine(p, j, height - myHeight1, j, height - myHeight2);

                                        myHeight3 = (int)(Math.Log(tempG) * 10);
                                        p.Color = Color.FromArgb(0, 255, 0);
                                        g.DrawLine(p, j, height - myHeight2, j, height - myHeight3);
                                    }
                                }

                            }
                        }
                    }
                }
                pictureBoxHist.Image = res;
                //pictureBoxHist.Image.Dispose();
                //res.Dispose();
                bmp.Dispose();
                //ménage
                //bmp.Dispose();
            }
            else if (selection.Count == 0)
            {
                searchSelection.Clear();

                richTextBoxSearchPersonnes.Text = "";
                richTextBoxSearchTags.Text = "";
                numericUpDownSearchEdit.Enabled = false;
                richTextBoxSearchPersonnes.Enabled = false;
                richTextBoxSearchTags.Enabled = false;
                buttonSearchCopy.Enabled = false;
                buttonSearchOpen.Enabled = false;
                buttonSearchSuppr.Enabled = false;
                numericUpDownSearchEdit.Value = 0;
                label12.Text = "Aucune photo sélectionnée";
                label15.Text = "Aucune photo sélectionnée";
                pictureBox2.Image = null;
                pictureBoxHist.Image = null;
                buttonSearchCopy.Enabled = false;
                buttonSearchOpen.Enabled = false;
                buttonSearchSuppr.Enabled = false;
            }

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
             */
        }

        
        private void numericUpDownSearchEdit_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private  void richTextBoxSearchTags_Validating(object sender, CancelEventArgs e)
        {
        }

        private void richTextBoxSearchPersonnes_Validating(object sender, CancelEventArgs e)
        {
            
        }
        
        //button enregistrer
        private async void buttonSearchOpen_Click(object sender, EventArgs e)
        {
            if (searchSelection.Count() == 1)
            {
                //maj des tags
                searchSelection.First().personnes.Clear();
                int length = richTextBoxSearchPersonnes.Lines.Length;
                for (int i = 0; i < length; i++)
                {
                    if (richTextBoxSearchPersonnes.Lines[i]!="") searchSelection.First().personnes.Add(richTextBoxSearchPersonnes.Lines[i]);
                }
                
                //maj des tags
                searchSelection.First().tags.Clear();
                length = richTextBoxSearchTags.Lines.Length;
                for (int i = 0; i < length; i++)
                {
                    if (richTextBoxSearchTags.Lines[i]!="") searchSelection.First().tags.Add(richTextBoxSearchTags.Lines[i]);
                }

                //maj de la note
                searchSelection.First().rating = (int)numericUpDownSearchEdit.Value;

                //enregistrement dans la BDD
                var builder = Builders<BsonDocument>.Filter;
                var filter = builder.Eq("path", searchSelection.First().path);
                searchSelection.First().generate_document();
                await iimages.ReplaceOneAsync(filter, searchSelection.First().doc);
                status.Text = "Changements enregistrés";
                refresh();
               
            }
        }

        private void buttonSearchCopy_Click(object sender, EventArgs e)
        {
            if (searchSelection.Count == 1)
            {
                System.Collections.Specialized.StringCollection paths = new System.Collections.Specialized.StringCollection();
                paths.Add(searchSelection.First().path);
                Clipboard.SetFileDropList(paths);
                status.Text = Path.GetFileNameWithoutExtension(searchSelection.First().path) + " copié dans le presse-papier";
            }
        }

        private void buttonSearchSuppr_Click(object sender, EventArgs e)
        {
            if (searchSelection.Count() ==1)
            {
                search.Remove(searchSelection.First());
                searchSelection.First().generate_document();
                iimages.DeleteOneAsync(searchSelection.First().doc);
                refresh();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void numericUpDownSearch_ValueChanged(object sender, EventArgs e)
        {
            refresh();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1) { refresh(); }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void richTextBoxSearchTags_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDownSearchEdit_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void disableEditing()
        {
            numericUpDownSearchEdit.Enabled = false;
            richTextBoxSearchPersonnes.Enabled = false;
            richTextBoxSearchTags.Enabled = false;
            richTextBoxSearchTags.Lines = new string[] { "" };
            richTextBoxSearchPersonnes.Lines = new string[] { "" };
            pictureBox2.Image = null ;
        }

        private void checkBoxAbove_CheckedChanged(object sender, EventArgs e)
        {
            refresh();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            refresh();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            var str = comboBoxTags.SelectedItem.ToString().Split('-');
            textBoxSearch.Text += " " + str[0];
        }

        private void comboBoxPersonnes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var str = comboBoxPersonnes.SelectedItem.ToString().Split('-');
            textBoxSearch.Text += " " + str[0];
        }

        


    }
}
