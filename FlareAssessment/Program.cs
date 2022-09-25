using BusinessLayer;
using Models;
using System;
using System.Collections.Generic;

namespace FlareAssessment
{
    public class Program
    {
        private static IRectangleService rectangleClass;
        static void Main(string[] args)
        {


            rectangleClass = new RectangleService();
            //RectangleService rectangleClass = new RectangleService();
            RectangleModel grid = new RectangleModel();

            grid = GetValidGridValues();

            List<RectangleModel> rectangleList = new List<RectangleModel>();
            bool isExit = false;
            RectangleModel invalidRectangle = null;
            while (!isExit)
            {

                RectangleModel rectangle = new RectangleModel();

                rectangle = GetValidRectangleValues();

                bool isInside = rectangleClass.IsInside(grid, rectangle);
                if (isInside)
                {
                    if (rectangleClass.IsOverLapped(rectangleList, rectangle))
                    {
                        Console.WriteLine("Invalid Rectangle.Overlapped");
                        invalidRectangle = new RectangleModel();
                        invalidRectangle = rectangle;

                    }
                    else
                    {
                        rectangleList.Add(rectangle);
                        Console.WriteLine("Valid Rectangle");
                    }
                }
                else
                {
                    Console.WriteLine("Provided rectangle is outside the grid");
                }

                DrawRectangles(grid, rectangleList, Console.CursorTop, invalidRectangle);
                Console.SetCursorPosition(0, Console.CursorTop + grid.Height + 2);
                invalidRectangle = null;

                Console.WriteLine("Enter E to exit,D for delete,A for Insert,F for find");
                string exitVal = Console.ReadLine();
                if (exitVal == "E")
                {
                    isExit = true;
                }
                else if (exitVal == "D")
                {
                    Point point = new Point();
                    Console.WriteLine("Enter Top,Left values");
                    point = GetValidRectangleTopLeftPoint();
                    rectangleList = rectangleClass.DeleteRectangle(rectangleList, point, out bool isValid, out string msg);
                    if (!isValid) Console.WriteLine(msg);
                    DrawRectangles(grid, rectangleList, Console.CursorTop, invalidRectangle);
                    Console.SetCursorPosition(0, Console.CursorTop + grid.Height + 2);

                }
                else if (exitVal == "F")
                {
                    Point point = new Point();
                    Console.WriteLine("Enter Top,Left values");

                    point = GetValidRectangleTopLeftPoint();
                    RectangleModel re = rectangleClass.GetRectangle(rectangleList, point);
                    if (re == null)
                    {
                        Console.WriteLine("Rectangle cannot found");
                    }
                    else
                    {
                        Console.WriteLine("Rectangle Found , Top:" + re.Top + "  Left:" + re.Left + " Height:" + re.Height + " Width:" + re.Width);
                        DrawRectangles(grid, re, Console.CursorTop);
                        Console.SetCursorPosition(0, Console.CursorTop + grid.Height + 2);
                    }

                }

            }

        }

        private static void DrawRectangles(RectangleModel grid, List<RectangleModel> rectangles, int cursorPoint, RectangleModel overlappedRectangle = null)
        {
            CreateRectabgle(0, 0, grid.Width, grid.Height, "*", true, cursorPoint);
            foreach (RectangleModel rectangle in rectangles)
            {
                CreateRectabgle(rectangle.Left, rectangle.Top, rectangle.Width, rectangle.Height, "O", false, cursorPoint);
            }
            if (overlappedRectangle != null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                CreateRectabgle(overlappedRectangle.Left, overlappedRectangle.Top, overlappedRectangle.Width, overlappedRectangle.Height, "X", false, cursorPoint);
                Console.ForegroundColor = ConsoleColor.White;
            }


        }
        private static void DrawRectangles(RectangleModel grid, RectangleModel rectangle, int cursorPoint)
        {
            CreateRectabgle(0, 0, grid.Width, grid.Height, "*", true, cursorPoint);
            CreateRectabgle(rectangle.Left, rectangle.Top, rectangle.Width, rectangle.Height, "O", false, cursorPoint);


        }
        private static RectangleModel GetValidGridValues()
        {
            RectangleModel model = new RectangleModel();
            bool isValid = false;
            while (!isValid)
            {
                Console.WriteLine("Insert grid values(Comma seperated): width,height");
                string inputs = Console.ReadLine();
                string[] inputArr = inputs.Split(',');
                model = rectangleClass.GetGridModel(inputArr, out string msg, out isValid);
                if (!isValid)
                {
                    Console.WriteLine(msg);
                }

            }
            return model;
        }
        private static RectangleModel GetValidRectangleValues()
        {
            RectangleModel model = new RectangleModel();
            bool isValid = false;
            while (!isValid)
            {
                Console.WriteLine("Insert rectangle values(Comma seperated): top,left,width,height");
                string inputs = Console.ReadLine();
                string[] inputArr = inputs.Split(',');
                string msg = "";
                model = rectangleClass.GetRectangleModel(inputArr, out msg, out isValid);
                if (!isValid)
                {
                    Console.WriteLine(msg);
                }

            }
            return model;
        }
        private static Point GetValidRectangleTopLeftPoint()
        {
            Point model = new Point();
            bool isValid = false;
            while (!isValid)
            {
                Console.WriteLine("Insert rectangle values(Comma seperated): top,left");
                string inputs = Console.ReadLine();
                string[] inputArr = inputs.Split(',');
                // string msg = "";
                model = rectangleClass.GetRectanglePointModel(inputArr, out string msg, out isValid);
                if (!isValid)
                {
                    Console.WriteLine(msg);
                }

            }
            return model;
        }


        private static void CreateRectabgle(int left, int top, int width, int height, string letter, bool isMainGrid, int cursorPoint)
        {
            for (int i = 0; i < width; i++)
            {
                if (!isMainGrid)
                {
                    Console.SetCursorPosition(left * 2, (cursorPoint + top + i));
                }
                //  Console.SetCursorPosition(left, top + i);
                for (int k = 0; k < height; k++)
                {
                    //Console.SetCursorPosition(8, 8 + i);
                    Console.Write(letter + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
