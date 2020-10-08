using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;
using System.Windows;

namespace WindowsFormsApp1
{
    class Autoit
    {
       public AutoItX3 auto = new AutoItX3();

        Vector a;
        int X;
        int Y;


        public void mClick(string ClickSide, int x, int y, int manyClick, int Speed)
        {
            auto.MouseClick(ClickSide, x,y,manyClick,Speed);
        }


        public void MouseClickDrag(string ClickSide, int x1, int y1, int nX2,int nY2)
        {
            auto.MouseClickDrag("LEFT", x1, y1, nX2, nY2);
            //strButton
        }



        public Vector GetPostion()
        {
            a = new Vector((int)auto.MouseGetPosX(), (int)auto.MouseGetPosY());
            return a;
        }
            
        public int GetPostionX()
        {
            int X = auto.MouseGetPosX();
            return X;
        }
        public int GetPostionY()
        {
            int Y = auto.MouseGetPosY();
            return Y;
        }

        public void Position(int x, int y)
        {
            auto.MouseMove(x, y);            
        }
        public string readPosition()
        {
            return ""+ auto.MouseGetPosX() + "," + auto.MouseGetPosY() ;
        }



        public int GetAction()
        {
            
            return auto.ProcessExists("02");
            ////auto.ProcessExists("LEFT");

            //auto.ProcessExists()
            //if (01 == auto.ProcessExists("LEFT"))
            //{
            //    return 01;
            //    //   auto.MouseDown("LEFT");
            //}
            //{
            //    return 02;
            //}
        }

        public void ClickLeft()
        {
            auto.MouseDown("LEFT");
            auto.MouseUp("LEFT");

        }
    }
}
