using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EZInput;

namespace g1
{
    public partial class Form1 : Form
    {
        PictureBox monster = new PictureBox();
        ProgressBar enemyHealth = new ProgressBar();
        ProgressBar PlayerHealth = new ProgressBar();
        public Form1()
        {
            InitializeComponent();
            Image img = Properties.Resources.monster;
            monster= createEnemy(img);
            this.Controls.Add( monster );
            setHeathBarCoord();
            setPlayerHealthCoord();
            Controls.Add(enemyHealth);
            Controls.Add(PlayerHealth);
        }

        Random rnd = new Random();
        private PictureBox createEnemy(Image img)
        {
            PictureBox enemy = new PictureBox();
            enemy.Image = img;
            enemy.Width = img.Width ;
            enemy.Height = img.Height;
            enemy.Left = rnd.Next(this.Left+20,this.Right-20);
            enemy.Top = rnd.Next(10,20);
            enemy.BackColor = Color.Transparent;
            return enemy;
        }
        List<PictureBox> FireList = new List<PictureBox>();
        List<PictureBox> FireListOfEnemy = new List<PictureBox>();
        List<PictureBox> MeteoroidLsit = new List<PictureBox>();

        private void setHeathBarCoord()
        {
            enemyHealth.Value = 100;
            enemyHealth.Left = monster.Left;
            enemyHealth.Top = monster.Top + 70;
        }
        private void setPlayerHealthCoord()
        {
            PlayerHealth.Value = 100;
            PlayerHealth.Left = player.Left;
            PlayerHealth.Top = player.Top + 70;
        }
        private void createBullet(Image img)
        {
            PictureBox bullet = new PictureBox();
            bullet.Image = img;
            bullet.Width = img.Width;
            bullet.Height = img.Height;
            bullet.Left = player.Left + (player.Width / 2) - 25; 
            bullet.Top = player.Top;
            bullet.BackColor = Color.Transparent;
            this.Controls.Add(bullet);
            this.FireList.Add(bullet );
        }
        Random Mrand = new Random();
        private PictureBox createMeteoroids()
        {
            PictureBox meteoroid = new PictureBox();
            Image Mimg = Properties.Resources.meteoroid;
            meteoroid.Image = Mimg;
            meteoroid.Width = 50;
            meteoroid.Height = 50;
            meteoroid.Left = Mrand.Next(this.Left + 20, this.Right - 20);
            meteoroid.Top = this.Top;
            return meteoroid;
        }
        private void addMeteoroidInList()
        {
            PictureBox meta = createMeteoroids();
            MeteoroidLsit.Add(meta);
            Controls.Add(meta);

        }
        private void moveMetaroid()
        {
            foreach(var m in MeteoroidLsit)
            {
                m.Top += 50;
            }
        }
        private void createBulletOfEnemey(Image img)
        {
            Image eImg = Properties.Resources.enemyBul;
            PictureBox bullett = new PictureBox();
            bullett.Image = eImg;
            bullett.Width = 50;
            bullett.Height = 50;
            bullett.Left = monster.Left + (monster.Width / 2) - 10;
            bullett.Top = monster.Top + 50;
            bullett.BackColor = Color.Transparent;
            this.Controls.Add(bullett);
            this.FireListOfEnemy.Add(bullett);
        }
        private void BulletCollisionWithPlayer()
        {
            for (int i = 0; i < FireListOfEnemy.Count; i++)
            {
                if (FireListOfEnemy[i].Bottom < 0)
                {
                    FireListOfEnemy[i].Dispose();

                }
                else if (FireListOfEnemy[i].Bounds.IntersectsWith(player.Bounds) && PlayerHealth.Value > 0)
                {
                    PlayerHealth.Value -= 10;
                    FireListOfEnemy[i].Dispose();
                }
                if (PlayerHealth.Value <= 0)
                {
                    player.Dispose();
                    PlayerHealth.Dispose();
                }
            }
        }

        string direction = "Left";
        int count = 0;
        int metaCount = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(Keyboard.IsKeyPressed(Key.LeftArrow) ) 
            {
                player.Left -= 20;
                PlayerHealth.Left -= 20;
            }
            else if(Keyboard.IsKeyPressed (Key.RightArrow) )
            {
                player.Left += 20;
                PlayerHealth.Left += 20;
            }
            else if(Keyboard.IsKeyPressed (Key.UpArrow))
            {
                player.Top -= 20;
                PlayerHealth.Top -= 20;
            }
            else if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                player.Top += 20;
                PlayerHealth.Top += 20;
            }
            if(Keyboard.IsKeyPressed(Key.Space))
            {
                Image bullet = Properties.Resources.fire;
                createBullet(bullet);
            }

            moveBullet();
            moveEnemyBullet();
            moveEnemy();
            count++;
            metaCount++;
            if(metaCount == 8)
            {

                addMeteoroidInList();
                metaCount = 0;
            }
                moveMetaroid();
            if (count == 8 && enemyHealth.Value > 0)
            {
                Image eBul = Properties.Resources.enemyBul;
                createBulletOfEnemey(eBul);
                count = 0;
            }
            for(int i = 0; i < FireList.Count; i++)
            {
                if(FireList[i].Bottom <0)
                {
                    FireList[i].Dispose();

                }
                else if(FireList[i].Bounds.IntersectsWith(monster.Bounds) && enemyHealth.Value > 0)
                {
                    enemyHealth.Value -= 10;
                    FireList[i].Dispose();
                }
                if(enemyHealth.Value <=0 )
                {
                    monster.Dispose();
                    enemyHealth.Dispose();
                }
            }
            BulletCollisionWithPlayer();
        }
        private void moveEnemy()
        {
            if(direction == "Left")
            {
                monster.Left -= 20;
                enemyHealth.Left -= 20;
            }
            else if(direction == "Right")
            {
                monster.Left += 20;
                enemyHealth.Left += 20;
            }
            if(monster.Left < 10)
            {
                direction = "Right";
            }
            if(monster.Left > this.Width - 100)
            {
                direction = "Left";
            }
        }
        private void moveBullet()
        {
            foreach(var b in FireList)
            {
                b.Top -= 50;
            }
        }
        private void moveEnemyBullet()
        {
            foreach (var b in FireListOfEnemy)
            {
                b.Top += 50;
            }
        }
        
    }
}
