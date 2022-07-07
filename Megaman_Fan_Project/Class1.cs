using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Megaman_Project
{
    public class Bullet
    {
        public int X;
        public int Y;
        public int speed;
        public int speedX;
        public int speedY;
        public int ratio;
        public int diffX;
        public int diffY;
        public Bitmap b;
        public int W;
        public int H;
        public int Bullet_tick;
        public int direction;
    }

    public class CActor
    {
        public int X, Y;
        public int W;
        public int ID;
    }

    public class Platform
    {
        public int X;
        public int Y;
        public Bitmap B;
    }
    public class Ladder
    {

        public int X;
        public int Y;
        public Bitmap B;
    }
    public class Img
    {
        public int curr_move;
        public List<Bitmap> Imgs = new List<Bitmap>();
    }
    public class Background_Images
    {
        public int X;
        public int Y;
        public Bitmap b;
    }
    public class Spike
    {
        public int X;
        public int Y;
        public Bitmap b;
    }
    public class bar
    {
        public int X;
        public int Y;
        public int W;
        public int H;
    }
    public class item
    {
        public int X;
        public int Y;
        public Bitmap P;
        public int type;
    }

    public class HealthCharacter
    {
        public int Health = 20;
        public List<bar> Bars = new List<bar>();
        public int LatestX;
    }
    public class Character
    {

        public int X;
        public int Y;
        public Bitmap b;
        public int curr_action;
        public int chargeBuster;
        public List<Bullet> bullets = new List<Bullet>();
        public List<Img> images = new List<Img>();
        public int currPlatform;
        public int direction = 1;
        public int lives = 3;
        public int snd_weapon_ready = 0;
        public int thrd_weapon_ready = 0;
        public int Shield = 0;
        public int Ammo = 140;
        public List<Shield> SH_D = new List<Shield>();

    }
    public class Shield
    {
        public int X;
        public int Y;
        public int Health = 55;
        public Bitmap P;
    }
    public class EyeEnemy
    {
        public int X;
        public int Y;
        public Bitmap b;
        public List<Bullet> bullets = new List<Bullet>();
        public List<Img> images = new List<Img>();
        public int direction;
        public int TickEye;
        public int Health;
    }
    public class ThunderEnemy
    {
        public int X;
        public int Y;
        public Bitmap b;
        public List<Bullet> bullets = new List<Bullet>();
        public List<Img> images = new List<Img>();
        public int direction;
        public int ThunderTick;
        public int Health;
    }

    public class BatEnemy
    {
        public int X;
        public int Y;
        public Bitmap b;
        public List<Bullet> bullets = new List<Bullet>();
        public List<Img> images = new List<Img>();
        public int direction;
        public int BatTick = 0;
        public int Health;
        public int currPlatform;
    }

    public class FireEnemy
    {
        public int X;
        public int Y;
        public Bitmap f;
        public List<Bullet> bullets = new List<Bullet>();
        public List<Img> images = new List<Img>();
        public int FETick;
        public int Health = 10;
    }
    public class shootingball
    {
        public int X;
        public int Y;
        public Bitmap ball;
    }
    public class PlatformLS
    {
        public List<Platform> Plats = new List<Platform>();
        public int Y;
        public int X;
        public int length;

    }

    public class LaserEnemy
    {
        public int X;
        public int Y;
        public Bitmap b;
        public List<Bullet> bullets = new List<Bullet>();
        public List<Img> images = new List<Img>();
        public int LaserTick = 0;
        public int currPlatform;

    }
    public class CSLice
    {
        public Rectangle rcDst;
        public Rectangle rcSrc;
        public Bitmap P;
    }


    public partial class Form1 : Form
    {
        Timer tt = new Timer();
        Bitmap off;
        Bitmap background = new Bitmap("background.png");
        int ctTick = 1;
        List<Character> CharList = new List<Character>();
        List<Platform> PL = new List<Platform>();
        List<PlatformLS> PLS = new List<PlatformLS>();
        List<EyeEnemy> EEL = new List<EyeEnemy>();
        List<shootingball> Ball = new List<shootingball>();
        List<FireEnemy> FE = new List<FireEnemy>();
        List<ThunderEnemy> THE = new List<ThunderEnemy>();
        List<Ladder> LAD = new List<Ladder>();
        List<Background_Images> BIMG = new List<Background_Images>();
        List<BatEnemy> BES = new List<BatEnemy>();
        HealthCharacter HC = new HealthCharacter();
        List<LaserEnemy> LE = new List<LaserEnemy>();
        List<CSLice> LSlices = new List<CSLice>();
        List<Spike> Spikes = new List<Spike>();
        List<item> Items = new List<item>();
        List<CActor> LActs = new List<CActor>();
        int score = 0;
        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            this.Paint += Form1_Paint;
            this.Load += Form1_Load1;
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;
            tt.Tick += Tt_Tick;
            tt.Start();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {

            }
            if (e.KeyCode == Keys.Up)
            {

            }
        }

        int count_buster = 0; int k = 0; int flag_shoot = -1;
        int r = 0; int flag_right = 0; int flag_up = 0; int currXX;
        int cr = 0; int re = 40; int rightfocus = 5; int ThunderEnFlag = 0; int checkLadder = 0; int stopmovingEyeEnemy = 0; int sub1 = 0;
        int runAir = 30; int BatFlag = 0; int cr2 = 0; int flag_ShieldAccept = 0; int even = 0;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && LActs[0].ID > 0)
            {
                LActs[0].ID--;
                if (CharList[0].direction == 1)
                {
                    Bullet Bull = new Bullet();
                    Bull.X = CharList[0].X + CharList[0].b.Width;
                    Bull.Y = CharList[0].Y + 20;
                    Bull.b = new Bitmap("busterlevel1.png");
                    Bull.direction = 1;
                    Bull.b.MakeTransparent(Bull.b.GetPixel(0, 0));
                    CharList[0].bullets.Add(Bull);
                    CharList[0].curr_action = 7;
                    if (flagAir == 0 && CharList[0].curr_action != 4)
                    {

                        cr++;
                        if (cr == 1) { CharList[0].Y += 8; }


                    }
                }
                if (CharList[0].direction == -1)
                {
                    Bullet Bull = new Bullet();
                    Bull.X = CharList[0].X - CharList[0].b.Width;
                    Bull.Y = CharList[0].Y + 20;
                    Bull.b = new Bitmap("busterlevel1Left.png");
                    Bull.b.MakeTransparent(Bull.b.GetPixel(0, 0));
                    Bull.direction = -1;
                    CharList[0].bullets.Add(Bull);
                    CharList[0].curr_action = 8;
                    if (flagAir == 0 && CharList[0].curr_action != 4)
                    {

                        cr++;
                        if (cr == 1) { CharList[0].Y += 8; }


                    }
                }

                flag_shoot = 1;
                count_buster++;
            }
            if (e.KeyCode == Keys.D1 && CharList[0].SH_D.Count != 0)
            {
                if (even % 2 == 0)
                {
                    flag_ShieldAccept = 1;
                }
                if (even % 2 == 1)
                {
                    flag_ShieldAccept = 0;
                }
                even++;
            }

            if (e.KeyCode == Keys.Right)
            {
                CharList[0].direction = 1;

                for (int i = 0; i < LSlices.Count; i++)
                {
                    LSlices[i].rcDst.X += 5;
                }
                System.Console.WriteLine(CharList[0].X);
                if (flagAir == 1)
                {
                    CharList[0].X += 20;
                }

                else
                {
                    CharList[0].X += 20;

                }
                if (flagAir == 0 && CharList[0].curr_action != 4)
                {

                    cr++;
                    if (cr == 1) { CharList[0].Y += 8; }
                    CharList[0].images[1].curr_move++;
                    CharList[0].curr_action = 1;
                    if (CharList[0].images[1].curr_move > 2)
                    {
                        CharList[0].images[1].curr_move = 0;
                    }
                }
                if (CharList[0].X + 40 >= PLS[4].Plats[0].X + PLS[4].Plats[0].B.Width && checkLadder == 1)
                {
                    flagAir = 1;
                    checkLadder = 0;
                    region_ladder_check = 0;
                }
                flag_right = 1;


            }
            if (e.KeyCode == Keys.Left)
            {
                CharList[0].direction = -1;

                for (int i = 0; i < LSlices.Count; i++)
                {
                    LSlices[i].rcDst.X -= 5;
                }
                if (flagAir == 1)
                {
                    CharList[0].X -= 20;
                }

                if (flagAir == 0 && CharList[0].curr_action != 4)
                {

                    cr++;
                    if (cr == 1) { CharList[0].Y += 8; }
                    CharList[0].X -= 20;
                    CharList[0].images[5].curr_move++;
                    CharList[0].curr_action = 5;
                    if (CharList[0].images[5].curr_move > 2)
                    {
                        CharList[0].images[5].curr_move = 0;
                    }

                }

            }

            if (e.KeyCode == Keys.Up)
            {

                if (checkLadder == 0)
                {
                    flagAir = 1;
                    flag_up = 1;
                    velocity = 1;
                    re = 30;
                    if (CharList[0].direction == 1)
                    {
                        CharList[0].images[2].curr_move++;
                        CharList[0].curr_action = 2;
                        if (CharList[0].images[2].curr_move > 1)
                        {
                            CharList[0].images[2].curr_move = 0;
                        }
                        re += 15;
                    }
                    if (CharList[0].direction == -1)
                    {
                        CharList[0].images[6].curr_move++;
                        CharList[0].curr_action = 6;
                        if (CharList[0].images[6].curr_move > 1)
                        {
                            CharList[0].images[6].curr_move = 0;
                        }
                        re += 15;
                    }
                }
                else if (CharList[0].curr_action == 4 && checkLadder == 1)
                {
                    flagAir = 0;
                    flag_up = 0;
                    CharList[0].Y -= 15;
                    checkLadder = 1;
                    CharList[0].images[4].curr_move++;
                    CharList[0].curr_action = 4;
                    if (CharList[0].images[4].curr_move > 1)
                    {
                        CharList[0].images[4].curr_move = 0;
                    }
                    CharList[0].Y -= 10;


                }
                if (CharList[0].Y <= PLS[4].Plats[0].Y && checkLadder == 1 && CharList[0].curr_action == 4)
                {
                    flagAir = 0;
                    checkLadder = 0;
                }


                else if (CharList[0].Y + CharList[0].images[CharList[0].curr_action].Imgs[0].Height >= PLS[4].Plats[0].Y + PLS[4].Plats[0].B.Height && CharList[0].Y <= PLS[4].Plats[0].Y + PLS[4].Plats[0].B.Height && flagAir == 1)
                {
                    if (CharList[0].X <= PLS[4].Plats[0].X + PLS[4].Plats[0].B.Width)
                    {

                        flagAir = 0;
                        CharList[0].curr_action = 4;
                        CharList[0].currPlatform = 4;
                        checkLadder = 1;
                    }

                }


            }
            if (e.KeyCode == Keys.Down)
            {
                if (region_ladder_check == 1)
                {

                    checkLadder = 1;
                }

                if (checkLadder == 1)
                {
                    CharList[0].images[4].curr_move++;
                    CharList[0].curr_action = 4;
                    if (CharList[0].images[4].curr_move > 1)
                    {
                        CharList[0].images[4].curr_move = 0;
                    }
                    CharList[0].Y += 10;

                }
                if (CharList[0].Y + CharList[0].images[CharList[0].curr_action].Imgs[0].Height >= PLS[4].Plats[0].Y + PLS[4].Plats[0].B.Height)
                {
                    flagAir = 1;
                    checkLadder = 0;
                    region_ladder_check = 0;

                }
                if (CharList[0].Y + CharList[0].images[CharList[0].curr_action].Imgs[0].Height >= PLS[4].Plats[0].Y + PLS[4].Plats[0].B.Height && CharList[0].curr_action == 4)
                {
                    flagAir = 1;
                    checkLadder = 0;
                    region_ladder_check = 0;
                }

            }
            if (e.KeyCode == Keys.A)
            {
                MoveElevator();
            }
            if (e.KeyCode == Keys.S)
            {
                MoveElevatorUp();
            }

        }
        int velocity = 0; int eyeEnFlag = 0; int df = 30; int y_velocity = 30; int counterthunder = 0; int checkLadderInside = 0;
        int Laser_shoot = -1;
        private void Tt_Tick(object sender, EventArgs e)
        {



            if (flagAir == 0)
            {
                velocity = 0; re = 20;

            }
            CheckAir();
            CheckLadderOut();

            for (int i = 0; i < CharList[0].bullets.Count; i++)
            {
                if (CharList[0].bullets[i].direction == 1)
                {
                    CharList[0].bullets[i].X += 10 + CharList[0].bullets[i].speed;
                    CharList[0].bullets[i].speed++;
                }
                if (CharList[0].bullets[i].direction == -1)
                {
                    CharList[0].bullets[i].X -= 10 + CharList[0].bullets[i].speed;
                    CharList[0].bullets[i].speed++;
                }
            }
            if (EEL.Count != 0)
            {
                MoveEyeEnemy();
                MoveEyeEnemyBullet();
                if (eyeEnFlag == 1)
                {
                    ShootEyeEnemyBullet();
                    eyeEnFlag = 0;
                }
            }

            if (BatFlag != 0 && sub1 != 1)
            {
                sub1 = 1;
                CreateBatEnemy();
            }

            if (BES.Count != 0)
            {
                if (BatFlag == 1)
                {
                    MoveBatEnemy();


                }
                MoveBatEnemyBullet();
                if (((BatFlag == 1) || (BatFlag == -1)))
                {
                    for (int i = 0; i < BES.Count; i++)
                    {
                        BES[i].BatTick++;
                        if (BES[i].BatTick == 4)
                        {
                            BES[i].images[i].curr_move++;
                            if (BES[i].images[i].curr_move == 2)
                            {
                                BES[i].images[i].curr_move = 0;
                                ShootBatEnemyBullet();
                            }
                            BES[i].BatTick = 0;

                        }
                    }


                }
            }
            if (THE.Count != 0)
            {
                MoveThunderEnemy();


                if (ThunderEnFlag == 1)
                {
                    ShootThunderEnemyBullet();
                    counterthunder++;
                    ThunderEnFlag = 2;
                }
                else if (counterthunder == 2)
                {
                    MoveThunderEnemyBullet();
                }
            }

            if (FE.Count != 0)
            {
                MoveFireEnemyBullet();
                if (FE[0].FETick == 3)
                {
                    FE[0].images[0].curr_move++;
                    if (FE[0].images[0].curr_move == 3)
                    {
                        CreateFireEnemyBullet();
                        FE[0].images[0].curr_move = 0;
                    }
                    FE[0].FETick = 0;
                }
                FE[0].FETick++;
            }
            DamageEnemy();
            ShootLaser();
            CollisionSpike();
            CheckItemColision();
            CheckLaserColision();
            Checkdead();
            ctTick++;


            for (int j = 0; j < CharList[0].SH_D.Count; j++)
            {
                if (CharList[0].direction == 1)
                {
                    if (CharList[0].SH_D.Count != 0)
                    {
                        CharList[0].SH_D[0].X = (CharList[0].X + CharList[0].images[CharList[0].curr_action].Imgs[0].Width) - 10;
                        CharList[0].SH_D[0].Y = CharList[0].Y + 20;
                    }
                }
                if (CharList[0].direction == -1)
                {

                    if (CharList[0].SH_D.Count != 0)
                    {
                        CharList[0].SH_D[0].X = (CharList[0].X - CharList[0].images[CharList[0].curr_action].Imgs[0].Width) + 10;
                        CharList[0].SH_D[0].Y = CharList[0].Y + 20;
                    }
                }
            }
            DrawDubb(CreateGraphics());


        }
        int na = 1;
        void CheckLadderOut()
        {
            if (CharList[0].X + 40 >= PLS[4].Plats[0].X + PLS[4].Plats[0].B.Width)
            {
                region_ladder_check = 0;
            }
            if (CharList[0].X <= PLS[4].Plats[0].X + PLS[4].Plats[0].B.Width && CharList[0].currPlatform == 4)
            {
                region_ladder_check = 1;
            }
        }
        void CollisionSpike()
        {
            int curr = CharList[0].images[0].curr_move;
            int curract = CharList[0].curr_action;

        }
        void ShootLaser()
        {
            if (LE[0].LaserTick == 0 || na == 1)
            {
                Bullet B = new Bullet();
                B.X = ((LE[0].X) + (LE[0].X + LE[0].images[0].Imgs[0].Width)) / 2;
                B.Y = LE[0].Y + 20;
                B.W = 10;
                B.H = 300;
                na = 0;
                LE[0].bullets.Add(B);
            }
            LE[0].LaserTick++;
            if (LE[0].LaserTick == 10)
            {
                LE[0].bullets.RemoveAt(0);
            }
            if (LE[0].LaserTick == 20)
            {
                LE[0].LaserTick = 0;
            }

        }
        void DamageEnemy()
        {
            int r = 0;
            for (int i = 0; i < CharList[0].bullets.Count; i++)
            {
                for (int j = 0; j < EEL.Count(); j++)
                {
                    if (CharList[0].bullets[i].X + CharList[0].bullets[i].b.Width - 20 >= EEL[j].X && CharList[0].bullets[i].X + CharList[0].bullets[i].b.Width - 20 <= EEL[j].X + EEL[j].images[0].Imgs[0].Width
                      && CharList[0].bullets[i].Y + 10 >= EEL[j].Y && CharList[0].bullets[i].Y + 10 <= EEL[j].Y + EEL[j].images[0].Imgs[0].Height
                      )
                    {
                        CharList[0].bullets.RemoveAt(i);
                        EEL[j].Health--;
                        if (EEL[j].Health == 0)
                        {
                            EEL.RemoveAt(j);
                        }
                        r = 1;
                        break;
                    }
                }
            }
            for (int i = 0; i < CharList[0].bullets.Count; i++)
            {
                for (int j = 0; j < THE.Count(); j++)
                {
                    if (CharList[0].bullets[i].X + CharList[0].bullets[i].b.Width + 30 >= THE[j].X && CharList[0].bullets[i].X + CharList[0].bullets[i].b.Width <= THE[j].X + THE[j].images[0].Imgs[0].Width + 30
                    && CharList[0].bullets[i].Y + 30 >= THE[j].Y && CharList[0].bullets[i].Y <= THE[j].Y + THE[j].images[0].Imgs[0].Height)
                    {
                        CharList[0].bullets.RemoveAt(i);
                        THE[j].Health--;
                        if (THE[j].Health == 0)
                        {
                            THE.RemoveAt(j);
                        }
                        r = 1;
                        break;
                    }
                    r = 0;


                }
            }

            for (int i = 0; i < CharList[0].bullets.Count; i++)
            {
                for (int j = 0; j < BES.Count(); j++)
                {
                    if (CharList[0].bullets[i].X + CharList[0].bullets[i].b.Width >= BES[j].X && CharList[0].bullets[i].X + CharList[0].bullets[i].b.Width <= BES[j].X + BES[j].images[0].Imgs[0].Width
                    && CharList[0].bullets[i].Y + 30 >= BES[j].Y && CharList[0].bullets[i].Y <= BES[j].Y + BES[j].images[0].Imgs[0].Height)
                    {
                        CharList[0].bullets.RemoveAt(i);
                        BES[j].Health--;
                        if (BES[j].Health == 0)
                        {
                            BES.RemoveAt(j);
                        }
                        r = 1;
                        break;
                    }
                    r = 0;


                }
            }
            for (int i = 0; i < CharList[0].bullets.Count; i++)
            {
                for (int j = 0; j < FE.Count(); j++)
                {
                    if (CharList[0].bullets[i].direction == -1)
                    {
                        if (CharList[0].bullets[i].X <= FE[j].X + FE[j].images[0].Imgs[0].Width
                       && CharList[0].bullets[i].X >= FE[j].X
                   && CharList[0].bullets[i].Y + 30 >= FE[j].Y && CharList[0].bullets[i].Y <= FE[j].Y + FE[j].images[0].Imgs[0].Height)
                        {
                            CharList[0].bullets.RemoveAt(i);
                            FE[j].Health--;
                            if (FE[j].Health == 0)
                            {
                                FE.RemoveAt(j);
                            }
                            r = 1;
                            break;
                        }
                    }

                    r = 0;


                }
            }

        }


        void MoveElevatorUp()
        {
            if (flagElevator == 1)
            {
                for (int i = 0; i < PLS[2].Plats.Count; i++)
                {

                    PLS[2].Plats[i].Y -= 5;

                }
            }
            if (flagElevator == 1)
            {
                CharList[0].Y -= 5;
            }
        }
        void MoveElevator()
        {
            if (flagElevator == 1)
            {
                for (int i = 0; i < PLS[2].Plats.Count; i++)
                {

                    PLS[2].Plats[i].Y += 5;

                }
            }
            if (flagElevator == 1)
            {
                CharList[0].Y += 5;
            }
        }

        void CheckLadder()
        {

            if (CharList[0].X + CharList[0].images[0].Imgs[0].Width < LAD[0].X + 50 && checkLadder == 1)
            {
                checkLadder = 0;
                region_ladder_check = 0;
                flagAir = 1;
            }
        }
        void ShootThunderEnemyBullet()
        {

            Bullet Bull = new Bullet();
            Bull.X = THE[0].X - THE[0].images[0].Imgs[0].Width;
            Bull.Y = THE[0].Y + 20;
            Bull.b = new Bitmap("ThunderBullet.bmp");
            Random RR = new Random();
            int sp = RR.Next(3, 5);
            Random RR2 = new Random();
            int rat = RR2.Next(1, 4);

            Bull.speed = sp;
            Bull.ratio = rat;
            Bull.b.MakeTransparent(Bull.b.GetPixel(0, 0));
            THE[0].bullets.Add(Bull);
            if (THE[0].bullets.Count == 2)
            {
                if (THE[0].bullets[0].ratio == THE[0].bullets[1].ratio)
                {
                    THE[0].bullets[1].ratio += 2;
                }
            }
        }
        int enderThunder = 0;
        void MoveThunderEnemyBullet()
        {

            for (int i = 0; i < THE[0].bullets.Count(); i++)
            {
                THE[0].bullets[i].X -= THE[0].bullets[i].speed;
                THE[0].bullets[i].speed += THE[0].bullets[i].ratio;
            }
            for (int i = 0; i < THE[0].bullets.Count(); i++)
            {
                if (THE[0].bullets[i].X < PLS[0].Plats[0].X)
                {
                    THE[0].bullets.RemoveAt(i);

                    enderThunder++;
                }
            }
            if (enderThunder == 2)
            {
                thunderCt = 0;
                enderThunder = 0;
                counterthunder = 0;
                moveEyeEcount = 0;

                ctTick = 10;
            }
            for (int i = 0; i < THE[0].bullets.Count; i++)
            {
                if (THE[0].bullets[i].X <= CharList[0].X + CharList[0].images[CharList[0].curr_action].Imgs[0].Width && THE[0].bullets[i].X >= CharList[0].X
                    && THE[0].bullets[i].Y + 30 >= CharList[0].Y && THE[0].bullets[i].Y + 30 <= CharList[0].Y + CharList[0].images[CharList[0].curr_action].Imgs[0].Height)
                {
                    enderThunder++;
                    if (flag_ShieldAccept == 0)
                    {
                        if (HC.Bars.Count != 0)
                        {
                            HC.Bars.RemoveAt((HC.Bars.Count()) - 1);
                            currXX -= HC.Bars[0].W;
                        }

                    }

                    if (flag_ShieldAccept == 1)
                    {
                        for (int j = 0; j < CharList[0].SH_D.Count; j++)
                        {
                            CharList[0].SH_D[j].Health--;
                            if (CharList[0].SH_D[j].Health == 0)
                            {
                                flag_ShieldAccept = 0;
                                CharList[0].SH_D.RemoveAt(j);
                            }
                        }
                    }
                    THE[0].bullets.RemoveAt(i);
                }

            }

        }



        int thunderCt = 0;
        void MoveThunderEnemy()
        {
            if (thunderCt < 2)
            {
                if (THE[0].ThunderTick == 10)
                {
                    if (THE[0].direction == 1)
                    {
                        thunderCt++;
                        THE[0].ThunderTick = 0;
                        THE[0].direction = -1;
                    }
                    else if (THE[0].direction == -1)
                    {
                        THE[0].ThunderTick = 0;
                        thunderCt++;
                        THE[0].direction = 1;
                    }
                    ThunderEnFlag = 1;
                }

                if (THE[0].direction == -1)
                {
                    THE[0].Y -= 10;
                }

                if (THE[0].direction == 1)
                {
                    THE[0].Y += 10;
                }
                THE[0].ThunderTick++;
            }

        }
        int moveEyeEcount = 0;
        void MoveEyeEnemy()
        {
            if (EEL[0].TickEye == 15)
            {
                if (EEL[0].direction == 1)
                {
                    moveEyeEcount++;
                    EEL[0].TickEye = 0;
                    EEL[0].direction = -1;
                }
                else if (EEL[0].direction == -1)
                {
                    moveEyeEcount++;
                    EEL[0].TickEye = 0;
                    EEL[0].direction = 1;

                }
                eyeEnFlag = 1;
            }
            EEL[0].TickEye++;
            if (EEL[0].direction == -1)
            {
                EEL[0].images[0].curr_move = 0;
                EEL[0].X -= 10;
            }

            if (EEL[0].direction == 1)
            {
                EEL[0].images[0].curr_move = 0;
                EEL[0].X += 10;
            }

        }

        void MoveBatEnemy()
        {
            for (int i = 0; i < BES.Count(); i++)
            {
                if (BES[i].BatTick != 10 && BES[i].BatTick >= 0)
                {
                    BES[i].Y -= 5;
                }
            }

        }

        void ShootBatEnemyBullet()
        {
            Bullet Bull = new Bullet();

            Bull.Y = BES[0].Y + 30;
            Bull.b = new Bitmap("EyeBullet.png");
            Bull.b.MakeTransparent(Bull.b.GetPixel(0, 0));
            int diff_X = CharList[0].X - BES[0].X;
            int diff_Y = CharList[0].Y - BES[0].Y;
            if (diff_X < 0) { Bull.X = BES[0].X; }
            if (diff_X > 0) { Bull.X = BES[0].X + BES[0].images[0].Imgs[0].Width; }
            diff_X = diff_X / 10;
            diff_Y = diff_Y / 10;
            Bull.diffX = diff_X;
            Bull.diffY = diff_Y;
            BES[0].bullets.Add(Bull);
        }
        void MoveBatEnemyBullet()
        {
            for (int i = 0; i < BES[0].bullets.Count(); i++)
            {
                if (BES[0].bullets[i].diffX < 0)
                {
                    BES[0].bullets[i].X += BES[0].bullets[i].diffX;
                }
                else if (BES[0].bullets[i].diffX > 0)
                {
                    BES[0].bullets[i].X += BES[0].bullets[i].diffX;
                }

                BES[0].bullets[i].Y += BES[0].bullets[i].diffY;
            }

            for (int i = 0; i < BES[0].bullets.Count; i++)
            {
                if (BES[0].bullets[i].X + 10 <= CharList[0].X + CharList[0].images[CharList[0].curr_action].Imgs[0].Width && BES[0].bullets[i].X >= CharList[0].X - 10
                    && BES[0].bullets[i].Y >= CharList[0].Y + 10 && BES[0].bullets[i].Y - 10 <= CharList[0].Y + CharList[0].images[CharList[0].curr_action].Imgs[0].Height)
                {

                    if (flag_ShieldAccept == 0)
                    {
                        if (HC.Bars.Count == 0)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                bar pnn = new bar();
                                pnn.X = currXX;
                                pnn.Y = 5;
                                pnn.W = 20;
                                pnn.H = 20;
                                currXX += pnn.W;
                                HC.Bars.Add(pnn);
                            }
                            CharList[0].X = 150;
                            CharList[0].Y = 290 - 250;
                            CharList[0].b = new Bitmap("idle.png");
                            CharList[0].b.MakeTransparent(CharList[0].b.GetPixel(0, 0));
                            flagAir = 1;
                        }
                        else
                        {
                            HC.Bars.RemoveAt((HC.Bars.Count()) - 1);
                        }

                    }

                    if (flag_ShieldAccept == 1)
                    {
                        for (int j = 0; j < CharList[0].SH_D.Count; j++)
                        {
                            CharList[0].SH_D[j].Health--;
                            if (CharList[0].SH_D[j].Health == 0)
                            {
                                flag_ShieldAccept = 0;
                                CharList[0].SH_D.RemoveAt(j);
                            }
                        }
                    }
                    BES[0].bullets.RemoveAt(i);
                }


            }
        }

        void ShootEyeEnemyBullet()
        {
            for (int i = 0; i < EEL.Count(); i++)
            {
                Bullet Bull = new Bullet();
                Bull.X = EEL[i].X - EEL[i].images[0].Imgs[0].Width;
                Bull.Y = EEL[i].Y + 20;
                Bull.b = new Bitmap("EyeBullet.png");
                Bull.b.MakeTransparent(Bull.b.GetPixel(0, 0));
                EEL[i].bullets.Add(Bull);
                EEL[i].images[0].curr_move = 1;
            }
        }
        void MoveEyeEnemyBullet()
        {
            for (int r = 0; r < EEL.Count; r++)
            {
                for (int i = 0; i < EEL[r].bullets.Count(); i++)
                {
                    EEL[r].bullets[i].X -= 10 + EEL[r].bullets[i].speed;
                    EEL[r].bullets[i].speed += 2;
                }
            }
            for (int i = 0; i < EEL[0].bullets.Count; i++)
            {
                if (EEL[0].bullets[i].X <= CharList[0].X + CharList[0].images[CharList[0].curr_action].Imgs[0].Width && EEL[0].bullets[i].X >= CharList[0].X
                    && EEL[0].bullets[i].Y + 10 >= CharList[0].Y && EEL[0].bullets[i].Y + 10 <= CharList[0].Y + CharList[0].images[CharList[0].curr_action].Imgs[0].Height)
                {
                    if (flag_ShieldAccept == 0)
                    {
                        if (HC.Bars.Count == 0)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                bar pnn = new bar();
                                pnn.X = currXX;
                                pnn.Y = 5;
                                pnn.W = 20;
                                pnn.H = 20;
                                currXX += pnn.W;
                                HC.Bars.Add(pnn);
                            }
                            CharList[0].X = 150;
                            CharList[0].Y = 290 - 250;
                            CharList[0].b = new Bitmap("idle.png");
                            CharList[0].b.MakeTransparent(CharList[0].b.GetPixel(0, 0));
                            flagAir = 1;
                        }
                        else
                        {
                            HC.Bars.RemoveAt((HC.Bars.Count()) - 1);
                        }

                    }

                    if (flag_ShieldAccept == 1)
                    {
                        for (int j = 0; j < CharList[0].SH_D.Count; j++)
                        {
                            CharList[0].SH_D[j].Health--;
                            if (CharList[0].SH_D[j].Health == 0)
                            {
                                flag_ShieldAccept = 0;
                                CharList[0].SH_D.RemoveAt(j);
                            }
                        }
                    }
                    EEL[0].bullets.RemoveAt(i);
                }

            }
        }


        void CreateFireEnemyBullet()
        {

            Bullet Bull = new Bullet();
            Bull.X = FE[0].X + FE[0].images[0].Imgs[0].Width;
            Bull.Y = FE[0].Y + 20;
            Bull.b = new Bitmap("FireBullet.bmp");
            Random RR = new Random();
            int SpeedX = RR.Next(30, 60);
            int SpeedY = RR.Next(4, 8);
            int diff = RR.Next(2, 4);
            Bull.speedX = SpeedX;
            Bull.speedY = SpeedY;
            Bull.ratio = diff;
            Bull.b.MakeTransparent(Bull.b.GetPixel(0, 0));
            FE[0].bullets.Add(Bull);
        }
        int hey = 10;
        void MoveFireEnemyBullet()
        {
            for (int j = 0; j < FE.Count; j++)
            {

                for (int i = 0; i < FE[0].bullets.Count(); i++)
                {
                    FE[0].bullets[i].X += FE[0].bullets[i].speedX;
                    FE[0].bullets[i].Y -= FE[0].bullets[i].speedY;
                    FE[0].bullets[i].speedY -= FE[0].bullets[i].ratio;
                }
            }
            for (int j = 0; j < FE.Count; j++)
            {
                for (int i = 0; i < FE[0].bullets.Count; i++)
                {
                    if (FE[0].bullets[i].X <= CharList[0].X + CharList[0].images[CharList[0].curr_action].Imgs[0].Width && FE[0].bullets[i].X >= CharList[0].X
                        && FE[0].bullets[i].Y + 10 >= CharList[0].Y && FE[0].bullets[i].Y + 10 <= CharList[0].Y + CharList[0].images[CharList[0].curr_action].Imgs[0].Height)
                    {

                        if (flag_ShieldAccept == 0)
                        {
                            if (HC.Bars.Count == 0)
                            {

                                for (int r = 0; r < 8; r++)
                                {
                                    bar pnn = new bar();
                                    pnn.X = currXX;
                                    pnn.Y = 5;
                                    pnn.W = 20;
                                    pnn.H = 20;
                                    currXX += pnn.W;
                                    HC.Bars.Add(pnn);
                                }
                                CharList[0].X = 150;
                                CharList[0].Y = 290 - 250;
                                CharList[0].b = new Bitmap("idle.png");
                                CharList[0].b.MakeTransparent(CharList[0].b.GetPixel(0, 0));
                                flagAir = 1;
                            }
                            else
                            {
                                HC.Bars.RemoveAt((HC.Bars.Count()) - 1);
                            }

                        }

                        if (flag_ShieldAccept == 1)
                        {
                            for (int r = 0; r < CharList[0].SH_D.Count; r++)
                            {
                                CharList[0].SH_D[j].Health--;
                                if (CharList[0].SH_D[j].Health == 0)
                                {
                                    flag_ShieldAccept = 0;
                                    CharList[0].SH_D.RemoveAt(j);
                                }
                            }
                        }
                        FE[0].bullets.RemoveAt(i);
                    }

                }
            }

        }
        int count = 0;
        void CheckCharacterColision()
        {
            for (int i = 0; i < PLS.Count; i++)
            {
                if (CharList[0].Y + 10 > PLS[i].Plats[0].Y && CharList[0].Y < PLS[i].Plats[0].Y + PLS[i].Plats[0].B.Height &&
                    CharList[0].Y + CharList[0].images[CharList[0].curr_action].Imgs[0].Height > PLS[i].Plats[0].Y + PLS[i].Plats[0].B.Height
                    && i != 4)
                {


                    if (CharList[0].X + 40 >= PLS[i].Plats[0].X
                             && CharList[0].X + CharList[0].images[0].Imgs[0].Width <= PLS[i].length + 20)
                    {

                        CharList[0].Y = PLS[i].Plats[0].Y + (CharList[0].images[0].Imgs[0].Height) - 40;
                        break;
                    }
                    System.Console.WriteLine("HEE" + count); count++;
                }
            }
        }
        void CheckBatEnemyColision()
        {
            for (int i = 0; i < PLS.Count; i++)
            {
                if (BES[0].Y > PLS[i].Plats[0].Y && BES[0].Y < PLS[i].Plats[0].Y + PLS[i].Plats[0].B.Height)
                {
                    BES[0].currPlatform = i;
                    if (BES[0].X + 40 >= PLS[BES[0].currPlatform].Plats[0].X
                        && BES[0].X + BES[0].images[0].Imgs[0].Width <= PLS[BES[0].currPlatform].length + 10)
                    {
                        BatFlag = -1;
                        BES[0].Y = PLS[i].Plats[0].Y + (BES[0].images[0].Imgs[0].Height) - 40;

                        break;
                    }
                }
            }
        }
        int e = 0;
        void Checkdead()
        {
            if (EEL.Count == 0 && FE.Count == 0 && THE.Count == 0 && BES.Count == 0 && e == 0)
            {
                item pnn = new item();
                e++;
                PLS.RemoveAt(9);
            }
        }
        void CheckItemColision()
        {
            int currItem = -1; int currindex = -1;

            for (int i = 0; i < Items.Count; i++)
            {
                if (CharList[0].X + CharList[0].images[CharList[0].curr_action].Imgs[0].Width >= Items[i].X
                   && CharList[0].X + CharList[0].images[CharList[0].curr_action].Imgs[0].Width <= Items[i].X + Items[i].P.Width
                   && CharList[0].Y + +CharList[0].images[CharList[0].curr_action].Imgs[0].Height >= Items[i].Y
                   && CharList[0].Y + CharList[0].images[CharList[0].curr_action].Imgs[0].Height - 20 <= Items[i].Y + Items[i].P.Height)
                {
                    currItem = Items[i].type;
                    currindex = i;
                    break;
                }

            }

            if (currItem == 1 && currindex != -1)
            {
                Items.RemoveAt(currindex);
                CharList[0].Shield = 1;

                if (CharList[0].direction == 1)
                {
                    Shield sh = new Shield();
                    sh.X = (CharList[0].X + CharList[0].images[CharList[0].curr_action].Imgs[0].Width) - 30;
                    sh.Y = CharList[0].Y + 20;
                    sh.Health = 30;
                    sh.P = new Bitmap("Shield1.png");
                    sh.P.MakeTransparent(sh.P.GetPixel(0, 0));
                    CharList[0].SH_D.Add(sh);
                }
            }

            if (currItem == 2 && currindex != -1)
            {

                Items.RemoveAt(currindex);
                int end = HC.Bars.Count - 1;
                int var = end + 1;
                for (int r = end; r >= 0; r--)
                {
                    HC.Bars.RemoveAt(r);
                }
                currXX = (this.Width / 2) - 400;

                for (int i = 0; i < var + 3; i++)
                {
                    bar pnn = new bar();
                    pnn.X = currXX;
                    pnn.Y = 5;
                    pnn.W = 20;
                    pnn.H = 20;
                    currXX += pnn.W;
                    HC.Bars.Add(pnn);
                }

            }
            if (currItem == 3 && currindex != -1)
            {
                Items.RemoveAt(currindex);
                LActs[1].ID += 10;
            }
        }

        void CheckLaserColision()
        {

            for (int i = 0; i < LE[0].bullets.Count; i++)
            {
                if (LE[0].bullets[0].X >= CharList[0].X
                   && LE[0].bullets[0].X + LE[0].bullets[0].W <= CharList[0].X + CharList[0].images[CharList[0].curr_action].Imgs[0].Width
                   && CharList[0].Y + +CharList[0].images[CharList[0].curr_action].Imgs[0].Height >= LE[0].bullets[0].Y
                   && CharList[0].Y + CharList[0].images[CharList[0].curr_action].Imgs[0].Height - 20 <= LE[0].bullets[0].Y + LE[0].bullets[0].H)
                {
                    CharList[0].X = 150;
                    CharList[0].Y = 290 - 250;
                    flagAir = 1;
                }
            }


        }
        void CheckAllEnemiesAreDead()
        {

        }

        void CheckCharacterGround()
        {
            for (int i = 0; i < PLS.Count; i++)
            {
                if (CharList[0].Y + CharList[0].images[CharList[0].curr_action].Imgs[0].Height + 10 >= PLS[i].Plats[0].Y && CharList[0].Y - 20 <= PLS[i].Plats[0].Y &&
                    (flagAir != 0)
                    && CharList[0].Y + CharList[0].images[CharList[0].curr_action].Imgs[0].Height <= PLS[i].Plats[0].Y + PLS[i].Plats[0].B.Height + 30)
                {
                    CharList[0].currPlatform = i;
                    if (CharList[0].currPlatform == 3)
                    {

                    }
                    if (CharList[0].X + 40 >= PLS[CharList[0].currPlatform].Plats[0].X
                        && CharList[0].X + CharList[0].images[0].Imgs[0].Width <= PLS[CharList[0].currPlatform].length + 20)
                    {
                        if (i == 2) { flagElevator = 1; }

                        if (i == 5 && countBatFlag != 1) { BatFlag = 1; countBatFlag = 1; }
                        CharList[0].curr_action = 3;
                        if (CharList[0].curr_action != 1) { CharList[0].Y = PLS[i].Plats[0].Y - (CharList[0].images[CharList[0].curr_action].Imgs[0].Height - 10); }

                        System.Console.WriteLine("GROUND POUND" + count);

                        flagAir = 0;
                        cr = 0;
                        s = 10;
                        velocity = 0;
                        runAir = 30;
                        re = 5;
                        break;
                    }
                }
            }
        }
        int s = 10; int flagAir = 1; int flagElevator = 0; int flagLadder = 0; int region_ladder_check = 0; int countBatFlag = 0;
        void CheckAir()
        {


            if (velocity == 1)
            {
                CharList[0].Y -= re;
                re -= 5;

                CheckCharacterColision();



            }

            CheckCharacterGround();

            if (flagAir != 0)
            {
                flagAir = 1;
                CharList[0].Y += s;
                if (CharList[0].direction == 1)
                {
                    CharList[0].curr_action = 2;
                }
                if (CharList[0].direction == -1)
                {
                    CharList[0].curr_action = 6;
                }
                s++;
            }


            if ((CharList[0].X + CharList[0].images[0].Imgs[0].Width > PLS[CharList[0].currPlatform].length || CharList[0].X + 40 < PLS[CharList[0].currPlatform].Plats[0].X)
     && (CharList[0].currPlatform == 2)
     )
            {

                if (flagElevator == 1) { flagElevator = 0; }
                flagAir = 1;
            }
            if ((CharList[0].X + CharList[0].images[0].Imgs[0].Width > PLS[CharList[0].currPlatform].length || CharList[0].X + 40 < PLS[CharList[0].currPlatform].Plats[0].X)
               && (CharList[0].currPlatform != 2)
               )
            {


                if (flagElevator == 1) { flagElevator = 0; }
                flagAir = 1;
            }



            if (BES.Count != 0)
            {
                CheckBatEnemyColision();
            }


        }

        int X_platf = 20;
        int Y_platf = 300;

        private void Form1_Load1(object sender, EventArgs e)
        {

            off = new Bitmap(ClientSize.Width, ClientSize.Height);
            Character c = new Character();
            c.X = 150;
            c.Y = 290 - 250;
            c.b = new Bitmap("idle.png");
            c.b.MakeTransparent(c.b.GetPixel(0, 0));
            c.currPlatform = 0;
            CharList.Add(c);
            CreateCharged(); //0
            CreateRight(); //1
            CreateJump(); //2
            CreatePlatform();
            CreateIdle();//3
            CreateClimb(); // 4
            CreateLeft(); // 5 
            CreateJumpLeft(); // 6
            CreateShoot(); // 7
            CreateShootLeft(); // 8
            CreateEyeEnemy();
            CreateFireEnemy();
            CreateThunderEnemy();
            CreateLaserEnemy();

            CreateSpike();
            CreateHealthBar();
            CreateBackground();
            CreateITEMS();
            CreateActor();
        }
        void CreateActor()
        {

            CActor pnn = new CActor();
            pnn.X = 330;
            pnn.Y = 10;


            pnn.W = 40;
            pnn.ID = CharList[0].Ammo;

            LActs.Add(pnn);

            pnn = new CActor();
            pnn.X = 220;
            pnn.Y = 10;


            pnn.W = 40;
            pnn.ID = score;
            LActs.Add(pnn);

        }
        void CreateITEMS()
        {
            item pnn = new item();
            pnn.X = 240;
            pnn.Y = 100;
            pnn.P = new Bitmap("Shield.png");
            pnn.type = 1;
            pnn.P.MakeTransparent(pnn.P.GetPixel(0, 0));
            Items.Add(pnn);

            pnn = new item();
            pnn.X = 640;
            pnn.Y = 100;
            pnn.P = new Bitmap("Heart.png");
            pnn.type = 2;
            pnn.P.MakeTransparent(pnn.P.GetPixel(0, 0));
            Items.Add(pnn);


            pnn = new item();
            pnn.X = 640;
            pnn.Y = 340;
            pnn.P = new Bitmap("Heart.png");
            pnn.type = 2;
            pnn.P.MakeTransparent(pnn.P.GetPixel(0, 0));
            Items.Add(pnn);

            pnn = new item();
            pnn.X = 640;
            pnn.Y = 100;
            pnn.P = new Bitmap("Coins.bmp");
            pnn.type = 3;
            pnn.P.MakeTransparent(pnn.P.GetPixel(0, 0));
            Items.Add(pnn);
            int currX = PLS[6].Plats[0].X + 20;
            int currY = PLS[6].Plats[0].Y - 40;
            for (int i = 0; i < 4; i++)
            {
                pnn = new item();
                pnn.X = currX;
                pnn.Y = currY;
                pnn.P = new Bitmap("Coins.bmp");
                pnn.type = 3;
                pnn.P.MakeTransparent(pnn.P.GetPixel(0, 0));
                currX += pnn.P.Width;
                Items.Add(pnn);
            }


            currX = PLS[7].Plats[0].X + 20;
            currY = PLS[7].Plats[0].Y - 40;
            for (int i = 0; i < 3; i++)
            {
                pnn = new item();
                pnn.X = currX;
                pnn.Y = currY;
                pnn.P = new Bitmap("Coins.bmp");
                pnn.type = 3;
                pnn.P.MakeTransparent(pnn.P.GetPixel(0, 0));
                currX += pnn.P.Width;
                Items.Add(pnn);
            }
        }
        void CreateShootLeft()
        {
            Img w = new Img();
            w.curr_move = 0;
            for (int i = 0; i < 1; i++)
            {
                Bitmap r = new Bitmap("LS" + i + ".png");
                r.MakeTransparent(r.GetPixel(0, 0));
                w.Imgs.Add(r);

            }

            CharList[0].images.Add(w);
        }
        void CreateShoot()
        {
            Img w = new Img();
            w.curr_move = 0;
            for (int i = 0; i < 1; i++)
            {
                Bitmap r = new Bitmap("S" + i + ".png");
                r.MakeTransparent(r.GetPixel(0, 0));
                w.Imgs.Add(r);

            }

            CharList[0].images.Add(w);
        }
        void CreateBackground()
        {
            Bitmap n = new Bitmap("Spike.png");
            n.MakeTransparent(n.GetPixel(0, 0));
            //  g.DrawImage(n, 270, 670);
            CSLice pnn = new CSLice();
            pnn.rcDst = new Rectangle(0, 0, this.Width, this.Height);
            pnn.rcSrc = new Rectangle(0, 0, background.Width, background.Height);
            pnn.P = new Bitmap("background.png");
            LSlices.Add(pnn);

            pnn = new CSLice();
            pnn.rcDst = new Rectangle(LSlices[0].rcDst.Width - 200, 0, this.Width, this.Height);
            pnn.rcSrc = new Rectangle(0, 0, background.Width, background.Height);
            pnn.P = new Bitmap("background.png");
            LSlices.Add(pnn);

            pnn = new CSLice();
            pnn.rcDst = new Rectangle(-500, 0, this.Width, this.Height);
            pnn.rcSrc = new Rectangle(0, 0, background.Width, background.Height);
            pnn.P = new Bitmap("background.png");
            LSlices.Add(pnn);


        }


        void CreateHealthBar()
        {
            currXX = (this.Width / 2) - 400; int currY = 5;
            for (int i = 0; i < 10; i++)
            {
                bar pnn = new bar();
                pnn.X = currXX;
                pnn.Y = currY;
                pnn.W = 20;
                pnn.H = 20;
                currXX += pnn.W;
                HC.Bars.Add(pnn);
            }

        }
        void CreateSpike()
        {
            Spike pnn = new Spike();
            pnn.X = 280;
            pnn.Y = 710;
            pnn.b = new Bitmap("Spike1.png");
            pnn.b.MakeTransparent(pnn.b.GetPixel(0, 0));
            Spikes.Add(pnn);
        }
        void CreateClimb()
        {
            Img w = new Img();
            w.curr_move = 0;
            for (int i = 0; i < 2; i++)
            {
                Bitmap r = new Bitmap("CL" + i + ".bmp");
                r.MakeTransparent(r.GetPixel(0, 0));
                w.Imgs.Add(r);

            }

            CharList[0].images.Add(w);
        }

        void CreateThunderEnemy()
        {
            Img w = new Img();
            w.curr_move = 0;
            for (int i = 0; i < 2; i++)
            {
                Bitmap r = new Bitmap("AirE" + i + ".bmp");
                r.MakeTransparent(r.GetPixel(0, 0));
                w.Imgs.Add(r);
            }

            ThunderEnemy pnn = new ThunderEnemy();
            pnn.X = 1000;
            pnn.Y = 290 - 200;
            pnn.ThunderTick = 0;
            pnn.images.Add(w);
            pnn.direction = -1;
            pnn.Health = 20;
            THE.Add(pnn);
        }
        void CreateFireEnemy()
        {
            Img w = new Img();
            w.curr_move = 0;
            for (int i = 0; i < 3; i++)
            {
                Bitmap r = new Bitmap("FE" + (i + 1) + ".bmp");
                r.MakeTransparent(r.GetPixel(0, 0));
                w.Imgs.Add(r);
            }

            FireEnemy pnn = new FireEnemy();
            pnn.X = 100;
            pnn.FETick = 0;
            pnn.Y = PLS[1].Plats[0].Y - 110;
            pnn.images.Add(w);
            FE.Add(pnn);



        }

        void CreateBatEnemy()
        {
            Img w = new Img();
            w.curr_move = 1;
            for (int i = 0; i < 2; i++)
            {
                Bitmap r = new Bitmap("BE" + (i + 1) + ".bmp");
                r.MakeTransparent(r.GetPixel(0, 0));
                w.Imgs.Add(r);
            }

            BatEnemy pnn = new BatEnemy();
            pnn.X = 700;
            pnn.Y = 330;
            pnn.Health = 6;
            pnn.images.Add(w);
            BES.Add(pnn);
        }
        void CreateIdle()
        {
            Img w = new Img();
            w.curr_move = 0;
            Bitmap r = new Bitmap("idle.png");
            r.MakeTransparent(r.GetPixel(0, 0));
            w.Imgs.Add(r);
            CharList[0].images.Add(w);
        }
        void CreatePlatform()
        {
            PlatformLS s = new PlatformLS();
            for (int i = 0; i < 8; i++)
            {
                Platform p = new Platform();
                p.X = X_platf;
                p.Y = 400 - 250;
                p.B = new Bitmap("Platform.png");
                p.B.MakeTransparent(p.B.GetPixel(0, 0));
                X_platf += p.B.Width;
                s.Plats.Add(p);
            }

            PLS.Add(s);
            PLS[0].length = X_platf;
            s = new PlatformLS();
            X_platf = 100;
            for (int i = 0; i < 20; i++)
            {
                Platform p = new Platform();
                p.X = X_platf;
                p.Y = 400;
                p.B = new Bitmap("Platform.png");
                p.B.MakeTransparent(p.B.GetPixel(0, 0));
                X_platf += p.B.Width;
                s.Plats.Add(p);
            }
            PLS.Add(s);
            PLS[1].length = X_platf;


            X_platf = 400 - 30;
            s = new PlatformLS();
            for (int i = 0; i < 4; i++)
            {
                Platform p = new Platform();
                p.X = X_platf;
                p.Y = 170;
                p.B = new Bitmap("Elevator.bmp");
                p.B.MakeTransparent(p.B.GetPixel(0, 0));
                X_platf += p.B.Width;
                s.Plats.Add(p);
            }
            PLS.Add(s);
            PLS[2].length = X_platf;

            s = new PlatformLS();

            for (int i = 0; i < 8; i++)
            {
                Platform p = new Platform();
                p.X = X_platf;
                p.Y = 400 - 250;
                p.B = new Bitmap("Platform.png");
                p.B.MakeTransparent(p.B.GetPixel(0, 0));
                X_platf += p.B.Width;
                s.Plats.Add(p);
            }

            PLS.Add(s);
            PLS[3].length = X_platf;


            s = new PlatformLS();
            Platform pL = new Platform();
            pL.X = 20;
            pL.Y = 400;
            pL.B = new Bitmap("photo.png");
            pL.B.MakeTransparent(pL.B.GetPixel(0, 0));
            s.Plats.Add(pL);
            PLS.Add(s);
            PLS[4].length = X_platf;



            s = new PlatformLS();
            X_platf = 20;
            for (int i = 0; i < 14; i++)
            {
                Platform p = new Platform();
                p.X = X_platf;
                p.Y = 750;
                p.B = new Bitmap("Platform2.bmp");
                p.B.MakeTransparent(p.B.GetPixel(0, 0));
                X_platf += p.B.Width;
                s.Plats.Add(p);
            }

            PLS.Add(s);
            PLS[5].length = X_platf;

            s = new PlatformLS();
            X_platf += 80;
            for (int i = 0; i < 5; i++)
            {
                Platform p = new Platform();
                p.X = X_platf;
                p.Y = 660;
                p.B = new Bitmap("Platform.png");
                p.B.MakeTransparent(p.B.GetPixel(0, 0));
                X_platf += p.B.Width;
                s.Plats.Add(p);
            }

            PLS.Add(s);
            PLS[6].length = X_platf;


            s = new PlatformLS();
            X_platf += 80;
            for (int i = 0; i < 5; i++)
            {
                Platform p = new Platform();
                p.X = X_platf;
                p.Y = 610;
                p.B = new Bitmap("Platform.png");
                p.B.MakeTransparent(p.B.GetPixel(0, 0));
                X_platf += p.B.Width;
                s.Plats.Add(p);
            }


            PLS.Add(s);
            PLS[7].length = X_platf;

            s = new PlatformLS();
            X_platf += 80;
            for (int i = 0; i < 5; i++)
            {
                Platform p = new Platform();
                p.X = X_platf;
                p.Y = 580;
                p.B = new Bitmap("Platform.png");
                p.B.MakeTransparent(p.B.GetPixel(0, 0));
                X_platf += p.B.Width;
                s.Plats.Add(p);
            }


            PLS.Add(s);
            PLS[8].length = X_platf;


            s = new PlatformLS();
            Y_platf = 80;
            for (int i = 0; i < 4; i++)
            {
                Platform p = new Platform();
                p.X = 1200;
                p.Y = Y_platf;
                p.B = new Bitmap("Platform2.bmp");
                p.B.MakeTransparent(p.B.GetPixel(0, 0));
                Y_platf += p.B.Height;
                s.Plats.Add(p);
            }


            PLS.Add(s);
            PLS[9].length = X_platf;

            s = new PlatformLS();
            Y_platf = 190;
            X_platf = 1240;
            for (int i = 0; i < 7; i++)
            {
                Platform p = new Platform();
                p.X = X_platf;
                p.Y = Y_platf;
                p.B = new Bitmap("Platform.png");
                p.B.MakeTransparent(p.B.GetPixel(0, 0));
                X_platf += p.B.Width;
                s.Plats.Add(p);
            }


            PLS.Add(s);
            PLS[10].length = X_platf;


            s = new PlatformLS();
            Y_platf = 390;
            X_platf = 1110;
            for (int i = 0; i < 4; i++)
            {
                Platform p = new Platform();
                p.X = X_platf;
                p.Y = Y_platf;
                p.B = new Bitmap("Platform.png");
                p.B.MakeTransparent(p.B.GetPixel(0, 0));
                X_platf += p.B.Width;
                s.Plats.Add(p);
            }


            PLS.Add(s);
            PLS[11].length = X_platf;


        }

        void CreateJump()
        {
            Img w = new Img();
            w.curr_move = 0;
            for (int i = 0; i < 2; i++)
            {
                Bitmap r = new Bitmap("J" + i + ".png");
                r.MakeTransparent(r.GetPixel(0, 0));
                w.Imgs.Add(r);

            }

            CharList[0].images.Add(w);
        }
        void CreateJumpLeft()
        {
            Img w = new Img();
            w.curr_move = 0;
            for (int i = 0; i < 2; i++)
            {
                Bitmap r = new Bitmap("JL" + i + ".png");
                r.MakeTransparent(r.GetPixel(0, 0));
                w.Imgs.Add(r);

            }

            CharList[0].images.Add(w);
        }
        void CreateRight()
        {
            Img w = new Img();
            w.curr_move = 0;
            for (int i = 0; i < 3; i++)
            {
                Bitmap r = new Bitmap("R" + i + ".png");
                r.MakeTransparent(r.GetPixel(0, 0));
                w.Imgs.Add(r);

            }

            CharList[0].images.Add(w);
        }
        void CreateCharged()
        {
            Img w = new Img();
            w.curr_move = 0;
            for (int i = 0; i < 5; i++)
            {
                Bitmap r = new Bitmap(i + "c" + ".png");
                r.MakeTransparent(r.GetPixel(0, 0));
                w.Imgs.Add(r);

            }
            CharList[0].images.Add(w);


        }

        void CreateLeft()
        {
            Img w = new Img();
            w.curr_move = 0;
            for (int i = 0; i < 3; i++)
            {
                Bitmap r = new Bitmap("L" + i + ".png");
                r.MakeTransparent(r.GetPixel(0, 0));
                w.Imgs.Add(r);

            }

            CharList[0].images.Add(w);
        }
        void CreateEyeEnemy()
        {
            Img w = new Img();
            w.curr_move = 0;
            for (int i = 0; i < 2; i++)
            {
                Bitmap r = new Bitmap("Eye" + i + ".bmp");
                r.MakeTransparent(r.GetPixel(0, 0));
                w.Imgs.Add(r);
            }

            EyeEnemy pnn = new EyeEnemy();
            pnn.X = 760;
            pnn.Y = 290 - 210;
            pnn.Health = 3;
            pnn.images.Add(w);
            pnn.direction = -1;
            EEL.Add(pnn);

            pnn = new EyeEnemy();
            pnn.X = 1400;
            pnn.Y = 500;
            pnn.Health = 3;
            pnn.images.Add(w);
            pnn.direction = -1;
            EEL.Add(pnn);

        }

        void CreateLaserEnemy()
        {
            Img w = new Img();
            w.curr_move = 0;
            for (int i = 0; i < 1; i++)
            {
                Bitmap r = new Bitmap("LSE" + (i + 1) + ".bmp");
                r.MakeTransparent(r.GetPixel(0, 0));
                w.Imgs.Add(r);
            }

            LaserEnemy pnn = new LaserEnemy();
            pnn.X = 140;
            pnn.Y = 435;
            pnn.images.Add(w);
            LE.Add(pnn);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(e.Graphics);
        }


        void DrawScene(Graphics g)
        {

            g.Clear(Color.White);

            Pen P = new Pen(Color.Black, 5);



            for (int i = 0; i < LSlices.Count; i++)
            {
                g.DrawImage(LSlices[0].P, LSlices[i].rcDst, LSlices[i].rcSrc, GraphicsUnit.Pixel);

            }

            for (int i = 0; i < Spikes.Count; i++)
            {
                g.DrawImage(Spikes[0].b, Spikes[0].X, Spikes[0].Y);
            }


            for (int j = 0; j < CharList[0].bullets.Count; j++)
            {
                g.DrawImage(CharList[0].bullets[j].b, CharList[0].bullets[j].X, CharList[0].bullets[j].Y);
            }
            if (EEL.Count != 0)
            {
                for (int i = 0; i < EEL.Count; i++)
                {
                    for (int j = 0; j < EEL[i].bullets.Count; j++)
                    {
                        g.DrawImage(EEL[i].bullets[j].b, EEL[i].bullets[j].X, EEL[i].bullets[j].Y);
                    }
                }
            }
            if (THE.Count != 0)
            {
                for (int j = 0; j < THE[0].bullets.Count; j++)
                {
                    g.DrawImage(THE[0].bullets[j].b, THE[0].bullets[j].X, THE[0].bullets[j].Y);
                }
            }

            for (int j = 0; j < LE[0].bullets.Count; j++)
            {
                g.FillRectangle(Brushes.Honeydew, LE[0].bullets[j].X, LE[0].bullets[j].Y, LE[0].bullets[j].W, LE[0].bullets[j].H);
            }

            for (int i = 0; i < FE.Count; i++)
            {
                for (int j = 0; j < FE[i].bullets.Count; j++)
                {
                    g.DrawImage(FE[i].bullets[j].b, FE[i].bullets[j].X, FE[i].bullets[j].Y);
                }
            }
            if (BES.Count != 0)
            {
                for (int j = 0; j < BES[0].bullets.Count; j++)
                {
                    g.DrawImage(BES[0].bullets[j].b, BES[0].bullets[j].X, BES[0].bullets[j].Y);
                }
            }
            for (int i = 0; i < PLS.Count(); i++)
            {
                for (int j = 0; j < PLS[i].Plats.Count; j++)
                {
                    g.DrawImage(PLS[i].Plats[j].B, PLS[i].Plats[j].X, PLS[i].Plats[j].Y);
                }
            }



            for (int i = 0; i < Ball.Count; i++)
            {
                g.DrawImage(Ball[0].ball, Ball[0].X, Ball[0].Y);
            }
            for (int i = 0; i < HC.Bars.Count; i++)
            {

                g.FillRectangle(Brushes.DarkOrange, HC.Bars[i].X, HC.Bars[i].Y, HC.Bars[i].W, HC.Bars[i].H);
                g.DrawRectangle(new Pen(Color.Black, 4),
                             HC.Bars[i].X, HC.Bars[i].Y,
                             HC.Bars[i].W, HC.Bars[i].H
                             );

            }

            if (EEL.Count != 0)
            {
                for (int j = 0; j < EEL.Count; j++)
                {
                    g.DrawImage(EEL[j].images[0].Imgs[EEL[j].images[0].curr_move], EEL[j].X, EEL[j].Y);
                }
            }
            for (int i = 0; i < THE.Count; i++)
            {
                g.DrawImage(THE[i].images[0].Imgs[THE[i].images[0].curr_move], THE[i].X, THE[i].Y);
            }
            if (BES.Count != 0) { g.DrawImage(BES[0].images[0].Imgs[BES[0].images[0].curr_move], BES[0].X, BES[0].Y); }
            if (LE.Count != 0) { g.DrawImage(LE[0].images[0].Imgs[LE[0].images[0].curr_move], LE[0].X, LE[0].Y); }
            for (int j = 0; j < FE.Count; j++)
            {
                g.DrawImage(FE[j].images[0].Imgs[FE[j].images[0].curr_move], FE[j].X, FE[j].Y);
            }
            int curr = CharList[0].curr_action;
            int innercurr = CharList[0].images[curr].curr_move;
            g.DrawImage(CharList[0].images[curr].Imgs[innercurr], CharList[0].X, CharList[0].Y);

            for (int i = 0; i < Items.Count; i++)
            {
                g.DrawImage(Items[i].P, Items[i].X, Items[i].Y);
            }
            if (flag_ShieldAccept == 1)
            {
                for (int i = 0; i < CharList[0].SH_D.Count; i++)
                {
                    g.DrawImage(CharList[0].SH_D[i].P, CharList[0].SH_D[i].X, CharList[0].SH_D[i].Y);
                }
            }
            for (int i = 0; i < LActs.Count; i++)
            {
                g.FillEllipse(Brushes.Yellow,
                                LActs[i].X, LActs[i].Y,
                                LActs[i].W, LActs[i].W
                                );

                if (i == 1)
                {
                    g.DrawEllipse(new Pen(Color.Blue, 5),
                               LActs[i].X, LActs[i].Y,
                               LActs[i].W, LActs[i].W
                               );
                }
                else
                {
                    g.DrawEllipse(new Pen(Color.Red, 5),
                                    LActs[i].X, LActs[i].Y,
                                    LActs[i].W, LActs[i].W
                                    );
                }
                g.DrawString("" + LActs[i].ID,
                              new Font("System", 20),
                              Brushes.Black,
                                LActs[i].X, LActs[i].Y
                            );

            }
        }



        void DrawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
        }
        static void Main(string[] args)
        {
            Form1 obj;
            obj = new Form1();
            Application.Run(obj);
        }

    }


}
