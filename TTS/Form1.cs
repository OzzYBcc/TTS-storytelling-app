using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;

namespace TTS
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        HttpClient client = new HttpClient();

        String connectionString = "Data source = stories.db;Version=3";
        SQLiteConnection connection;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ChangeColor.SetFormColor(this, Color.Gray);

            foreach (InstalledVoice voice in synthesizer.GetInstalledVoices())
            {
                comboBox1.Items.Add(voice.VoiceInfo.Name);
            }

            comboBox2.Items.Add("--Aesop--");
            comboBox2.Items.Add("A Raven And A Swan");
            comboBox2.Items.Add("--Classics--");
            comboBox2.Items.Add("Winter in the Boulevard");
            comboBox2.Items.Add("--Kids--");
            comboBox2.Items.Add("The Adventures of Sunny the Squirrel");
            comboBox2.Items.Add("--Sci-Fi--");
            comboBox2.Items.Add("The Signal");
            comboBox2.Items.Add("--Winter--");
            comboBox2.Items.Add("The Lost Christmas Star");

            connection = new SQLiteConnection(connectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            synthesizer.SpeakAsync(richTextBox1.Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            synthesizer.SelectVoice(comboBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (synthesizer.State == SynthesizerState.Speaking)
            {
                synthesizer.Pause();
            }
            else if (synthesizer.State == SynthesizerState.Paused)
            {
                synthesizer.Resume();
            }
            else
            {
                MessageBox.Show("There is nothing playing at the moment! Try playing something.");
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            synthesizer.Volume = trackBar1.Value;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            label3.Text = "";
            textBox1.Clear();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            synthesizer.Rate = trackBar2.Value;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem?.ToString() == "A Raven And A Swan")
            {
                richTextBox1.Text = "A Raven, which you know is black as coal, was envious of the Swan, because her feathers were as white as the purest snow. The foolish bird got the idea that if he lived like the Swan, swimming and diving all day long and eating the weeds and plants that grow in the water, his feathers would turn white like the Swan's.\n\nSo he left his home in the woods and fields and flew down to live on the lakes and in the marshes. But though he washed and washed all day long, almost drowning himself at it, his feathers remained as black as ever.And as the water weeds he ate did not agree with him, he got thinner and thinner, and at last he died.\n\nA change of habits will not alter nature.";
                label3.Text = "Aesop";
                textBox1.Text = "A  Raven And A Swan";
            }
            else if (comboBox2.SelectedItem?.ToString() == "Winter in the Boulevard")
            {
                richTextBox1.Text = "The frost has settled down upon the trees. And ruthlessly strangled off the fantasies. Of leaves that have gone unnoticed, swept like old. Romantic stories now no more to be told.\n\nThe trees down the boulevard stand naked in thought, their abundant summery wordage silenced, caught. In the grim undertow; naked the trees confront. Implacable winter's long, cross-questioning brunt.Has some hand balanced more leaves in the depths of the twigs? Some dim little efforts placed in the threads of the birch?\n\nIt is only the sparrows, like dead black leaves on the sprigs, Sitting huddled against the cerulean, one flesh with their perch.The clear, cold sky coldly bethinks itself.\n\nLike vivid thought the air spins bright, and all. Trees, birds, and earth, arrested in the after-thought. Awaiting the sentence out from the welkin brought.";
                label3.Text = "Classics";
                textBox1.Text = "Winter in the Boulevard";
            }
            else if (comboBox2.SelectedItem?.ToString() == "The Adventures of Sunny the Squirrel")
            {
                richTextBox1.Text = "Once upon a time in a peaceful forest, there lived a cheerful squirrel named Sunny. Sunny loved exploring the forest, always curious about the world beyond the tall trees. One day, while gathering acorns for winter, Sunny found a shiny golden nut stuck in the roots of an old oak tree.\r\n\r\nSunny tugged and pulled until the nut popped free, revealing a tiny door beneath it. The door opened, and out came a magical fairy! \"Thank you, Sunny! You’ve freed me from a long spell. In return, I’ll grant you one wish.\"\r\n\r\nSunny thought carefully. \"I wish for all the animals in the forest to have enough food for winter!\"\r\n\r\nThe fairy waved her wand, and suddenly, the trees were filled with nuts, berries, and fruits. All the animals cheered, thanking Sunny for their feast. From that day on, Sunny was known as the hero of the forest.";
                label3.Text = "Kids";
                textBox1.Text = "The Adventures of Sunny the Squirrel";
            }
            else if (comboBox2?.SelectedItem?.ToString() == "The Signal")
            {
                richTextBox1.Text = "In the year 3057, Earth had become a bustling hub of intergalactic civilizations. Maya, a young astrophysicist, worked at the Deep Space Listening Station. One evening, while analyzing data, Maya noticed a strange pattern in a distant galaxy—an intelligent signal repeating in prime numbers.\r\n\r\nMaya deciphered the signal and found coordinates for an unknown planet. Against orders, she joined a covert expedition to investigate. When the team landed, they discovered a city made of pure energy, inhabited by beings of light.\r\n\r\nThe beings communicated telepathically, revealing they sent the signal as a test to find peaceful civilizations. Impressed by Maya's courage and intelligence, they shared advanced technology to restore Earth's ecosystem.\n\nReturning home, Maya became a hero, proving that curiosity and bravery could unlock the universe’s greatest secrets.";
                label3.Text = "Sci-Fi";
                textBox1.Text = "The Signal";
            }
            else if (comboBox2.SelectedItem?.ToString() == "The Lost Christmas Star")
            {
                richTextBox1.Text = "It was Christmas Eve, and the little town of Hollyville was bustling with holiday cheer. But something was missing—the star atop the giant Christmas tree in the town square! Without the star, the tree looked incomplete, and everyone felt disappointed.\n\nEllie, a brave 10-year-old girl, decided to search for the missing star. With her trusty dog Max, she followed glittering footprints leading into the forest. They found a mischievous elf named Jingle, who had taken the star by mistake, thinking it was a magical toy.\n\nEllie explained how important the star was to the town. Feeling guilty, Jingle returned it, and together they placed it atop the tree just as the clock struck midnight. The star lit up the night sky, and everyone cheered. Santa himself appeared, praising Ellie for her determination.\n\nFrom that night on, Ellie’s bravery became part of Hollyville's Christmas legend.";
                label3.Text = "Winter";
                textBox1.Text = "The Lost Christmas Star";
            }

            string selectedItem = comboBox2.SelectedItem?.ToString();

            if (selectedItem != null && selectedItem.StartsWith("--") && selectedItem.EndsWith("--"))
            {
                MessageBox.Show("You cannot select a category. Please choose a story.");
                comboBox2.SelectedIndex = -1;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            connection.Open();
            String insert = "INSERT INTO Categories (Category, Title, Story) VALUES (@Category, @Title, @Story)";
            SQLiteCommand command = new SQLiteCommand(insert, connection);
            command.Parameters.AddWithValue("@Category", label3.Text);
            command.Parameters.AddWithValue("@Title", textBox1.Text);
            command.Parameters.AddWithValue("@Story", richTextBox1.Text);

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Story added to database!");
            }
            else
            {
                MessageBox.Show("There was an error!");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private async void button5_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "https://shortstories-api.onrender.com";

                try
                {
                    var response = await client.GetStringAsync(apiUrl);

                    var storyData = JsonConvert.DeserializeObject<Dictionary<string, string>>(response);
                    storyData?.Remove("_id");

                    textBox1.Text = storyData["title"];
                    richTextBox1.Text = storyData["story"];
                    label3.Text = "Aesop";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        public class RateButton
        {
            public void Redirect(string url)
            {
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Σφάλμα κατά το άνοιγμα του συνδέσμου: {ex.Message}", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RateButton RateButton = new RateButton();
            RateButton.Redirect("https://play.google.com/store/games?device=windows");
        }
    }
}

public class ChangeColor
{
    public static void SetFormColor(Form form, Color color)
    {
        if (form != null)
        {
            form.BackColor = color;
        }
    }
}