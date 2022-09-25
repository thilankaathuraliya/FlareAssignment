using Xunit;
using BusinessLayer;
using System;
using Models;
using System.Collections.Generic;

namespace UnitTest
{
    public class UnitTestsRectangleService
    {
        public static IRectangleService? rectangleClass;


        [Fact]
        public void DeleteRectangle_DeletedSuccessfully()
        {
            rectangleClass = new RectangleService();
            List<RectangleModel> rectangleList = new List<RectangleModel>();
            RectangleModel rec1 = new RectangleModel();
            rec1.Top = 2;
            rec1.Left = 2;
            rec1.Height = 2;
            rec1.Width = 2;

            RectangleModel rec2 = new RectangleModel();
            rec2.Top = 5;
            rec2.Left = 5;
            rec2.Height = 2;
            rec2.Width = 2;

            rectangleList.Add(rec1);
            rectangleList.Add(rec2);

            Point point = new Point();
            point.X = 3;
            point.Y = 3;

            string msg = "";
            bool isValid = false;

            var model = rectangleClass.DeleteRectangle(rectangleList, point, out isValid, out msg);

            Assert.True(isValid);
            Assert.Equal(msg, "Rectangle Deleted");
            Assert.Equal(rectangleList.Count, 1);
            // List<RectangleModel> rectangleList, Point point, out bool isValid, out string msg






           
        }

        [Fact]
        public void DeleteRectangle_NotFound()
        {
            rectangleClass = new RectangleService();
            List<RectangleModel> rectangleList = new List<RectangleModel>();
            RectangleModel rec1 = new RectangleModel();
            rec1.Top = 2;
            rec1.Left = 2;
            rec1.Height = 2;
            rec1.Width = 2;

            RectangleModel rec2 = new RectangleModel();
            rec2.Top = 5;
            rec2.Left = 5;
            rec2.Height = 2;
            rec2.Width = 2;

            rectangleList.Add(rec1);
            rectangleList.Add(rec2);

            Point point = new Point();
            point.X = 13;
            point.Y = 13;

            string msg = "";
            bool isValid = false;

            var model = rectangleClass.DeleteRectangle(rectangleList, point, out isValid, out msg);

            Assert.False(isValid);
            Assert.Equal("Rectangle Not Found",msg);
            Assert.Equal(2,rectangleList.Count);
        }


        [Fact]
        public void GetRectangle_NotFound()
        {
            rectangleClass = new RectangleService();
            List<RectangleModel> rectangleList = new List<RectangleModel>();
            RectangleModel rec1 = new RectangleModel();
            rec1.Top = 2;
            rec1.Left = 2;
            rec1.Height = 2;
            rec1.Width = 2;

            RectangleModel rec2 = new RectangleModel();
            rec2.Top = 5;
            rec2.Left = 5;
            rec2.Height = 2;
            rec2.Width = 2;

            rectangleList.Add(rec1);
            rectangleList.Add(rec2);

            Point point = new Point();
            point.X = 13;
            point.Y = 13;

            var model = rectangleClass.GetRectangle(rectangleList, point);

            Assert.Null(model);
        }

        [Fact]
        public void GetRectangle_Found()
        {
            rectangleClass = new RectangleService();
            List<RectangleModel> rectangleList = new List<RectangleModel>();
            RectangleModel rec1 = new RectangleModel();
            rec1.Top = 2;
            rec1.Left = 2;
            rec1.Height = 2;
            rec1.Width = 2;

            RectangleModel rec2 = new RectangleModel();
            rec2.Top = 5;
            rec2.Left = 5;
            rec2.Height = 2;
            rec2.Width = 2;

            rectangleList.Add(rec1);
            rectangleList.Add(rec2);

            Point point = new Point();
            point.X = 3;
            point.Y = 3;

            var model = rectangleClass.GetRectangle(rectangleList, point);

            Assert.NotNull(model);
        }



        [Theory]
        [InlineData(3, 3, 2,2)]
        [InlineData(3, 3, 3, 3)]
        [InlineData(3, 3, 3, 2)]
        [InlineData(6, 6, 3, 2)]
        public void RectangleIsOverLapped_True(int top,int left,int height,int width)
        {
            rectangleClass = new RectangleService();
            List<RectangleModel> rectangleList = new List<RectangleModel>();
            RectangleModel rec1 = new RectangleModel();
            rec1.Top = 2;
            rec1.Left = 2;
            rec1.Height = 2;
            rec1.Width = 2;

            RectangleModel rec2 = new RectangleModel();
            rec2.Top = 5;
            rec2.Left = 5;
            rec2.Height = 2;
            rec2.Width = 2;

            rectangleList.Add(rec1);
            rectangleList.Add(rec2);

            RectangleModel rec_check = new RectangleModel();
            rec_check.Top = top;
            rec_check.Left = left;
            rec_check.Height = height;
            rec_check.Width = width;



            var status = rectangleClass.IsOverLapped(rectangleList, rec_check);

            Assert.True(status);
        }

        [Theory]
        [InlineData(0, 0, 1, 1)]
        [InlineData(0, 1, 1, 1)]
        [InlineData(8, 8, 3, 2)]
        [InlineData(9, 9, 3, 2)]
        public void RectangleIsOverLapped_False(int top, int left, int height, int width)
        {
            rectangleClass = new RectangleService();
            List<RectangleModel> rectangleList = new List<RectangleModel>();
            RectangleModel rec1 = new RectangleModel();
            rec1.Top = 2;
            rec1.Left = 2;
            rec1.Height = 2;
            rec1.Width = 2;

            RectangleModel rec2 = new RectangleModel();
            rec2.Top = 5;
            rec2.Left = 5;
            rec2.Height = 2;
            rec2.Width = 2;

            rectangleList.Add(rec1);
            rectangleList.Add(rec2);

            RectangleModel rec_check = new RectangleModel();
            rec_check.Top = top;
            rec_check.Left = left;
            rec_check.Height = height;
            rec_check.Width = width;



            var status = rectangleClass.IsOverLapped(rectangleList, rec_check);

            Assert.False(status);
        }


        [Theory]
        [InlineData(2, 2, 2, 2,3,3,3,3)]
        [InlineData(2, 8, 3, 2,3,3,3,3)]
        [InlineData(0, 0, 3, 3,2,2,2,2)]
        public void RectangleIsInside_False(int r1X,int r1Y,int r1Width,int r1Height, int r2X, int r2Y, int r2Width, int r2Height)
        {
            rectangleClass = new RectangleService();
            
            RectangleModel rec1 = new RectangleModel();
            rec1.Top = r1Y;
            rec1.Left = r1X;
            rec1.Height = r1Height;
            rec1.Width = r1Width;

            RectangleModel rec2 = new RectangleModel();
            rec2.Top = r2Y;
            rec2.Left = r2X;
            rec2.Height = r2Height;
            rec2.Width = r2Width;

            var res = rectangleClass.IsInside(rec1, rec2);


            Assert.False(res);
        }

        [Theory]
        [InlineData(0, 0, 12, 12, 3, 3, 3, 3)]
        [InlineData(1, 1, 20, 20, 3, 3, 3, 3)]
        [InlineData(5, 5, 13, 13, 2, 2, 2, 2)]
        public void RectangleIsInside_True(int r1X, int r1Y, int r1Width, int r1Height, int r2X, int r2Y, int r2Width, int r2Height)
        {
            rectangleClass = new RectangleService();

            RectangleModel rec1 = new RectangleModel();
            rec1.Top = r1Y;
            rec1.Left = r1X;
            rec1.Height = r1Height;
            rec1.Width = r1Width;

            RectangleModel rec2 = new RectangleModel();
            rec2.Top = r2Y;
            rec2.Left = r2X;
            rec2.Height = r2Height;
            rec2.Width = r2Width;

            var res = rectangleClass.IsInside(rec1, rec2);


            Assert.True(res);
        }

        [Theory]
        [InlineData(0, 0, 3, 3)]
        [InlineData(1, 1, 4, 4)]
        [InlineData(5, 5, 2, 2)]
        public void RectangleIsValid_True(int x, int y, int height, int width)
        {
            rectangleClass = new RectangleService();

            RectangleModel rec = new RectangleModel();
            rec.Top = x;
            rec.Left = y;
            rec.Height = height;
            rec.Width = width;


            var res = rectangleClass.IsValid(rec);


            Assert.True(res);
        }

        [Theory]
        [InlineData(-1, 0, 3, 3)]
        [InlineData(1, -1, 4, 4)]
        [InlineData(5, 5, 0, 0)]
        public void RectangleIsValid_False(int x, int y, int height, int width)
        {
            rectangleClass = new RectangleService();

            RectangleModel rec = new RectangleModel();
            rec.Top = x;
            rec.Left = y;
            rec.Height = height;
            rec.Width = width;


            var res = rectangleClass.IsValid(rec);


            Assert.False(res);
        }

        [Theory]
        [InlineData(-1, 0, 3, 3)]
        [InlineData(1, -1, 4, 4)]
        [InlineData(5, 5, 0, 0)]
        public void RectangleDoOverlap_True(int x, int y, int height, int width)
        {
            rectangleClass = new RectangleService();

            RectangleModel rec = new RectangleModel();
            rec.Top = x;
            rec.Left = y;
            rec.Height = height;
            rec.Width = width;


            var res = rectangleClass.IsValid(rec);


            Assert.False(res);
        }

        [Theory]
        [InlineData("5,5")]
        [InlineData("25,25")]
        [InlineData("10,10")]
        [InlineData("20,20")]
        public void GetGridModel_True(string value)
        {
            rectangleClass = new RectangleService();

            string[] values = value.Split(',');

            string msg = "";
            bool isValid = false;

            var res = rectangleClass.GetGridModel(values,out msg,out isValid);


            Assert.True(isValid);
            Assert.Empty(msg);
            Assert.NotNull(res);
        }

        [Theory]
        [InlineData("-5,-5")]
        [InlineData("2,2")]
        [InlineData("26,26")]
        [InlineData("2,20")]
        [InlineData("-2,10")]
        [InlineData("-2,10,1,1")]
        public void GetGridModel_False(string value)
        {
            rectangleClass = new RectangleService();

            string[] values = value.Split(',');

            string msg = "";
            bool isValid = false;

            var res = rectangleClass.GetGridModel(values, out msg, out isValid);

            Assert.False(isValid);
            Assert.Equal("Invalid Inputs:Please use width,height",msg);
            Assert.Null(res);
        }

        [Theory]
        [InlineData("5,5,5,5")]
        [InlineData("2,2,2,2")]
        [InlineData("1,2,4,4")]
        [InlineData("3,5,3,3")]
        public void GetRectangleModel_True(string value)
        {
            rectangleClass = new RectangleService();

            string[] values = value.Split(',');

            string msg = "";
            bool isValid = false;

            var res = rectangleClass.GetRectangleModel(values, out msg, out isValid);

            Assert.True(isValid);
            Assert.Equal("",msg);
            Assert.NotNull(res);
        }

        [Theory]
        [InlineData("5,5")]
        [InlineData("2,2,-2,2")]
        [InlineData("-1,2,-4,4")]
        [InlineData("-3,5,3,3")]
        public void GetRectangleModel_False(string value)
        {
            rectangleClass = new RectangleService();

            string[] values = value.Split(',');

            string msg = "";
            bool isValid = false;

            var res = rectangleClass.GetRectangleModel(values, out msg, out isValid);

            Assert.False(isValid);
            Assert.Equal("Invalid Inputs:Please use top,left,width,height", msg);
            Assert.Null(res);
        }

        [Theory]
        [InlineData("2,2")]
        [InlineData("2,4")]
        [InlineData("6,4")]
        [InlineData("2,5")]
        public void GetRectanglePointModel_True(string value)
        {
            rectangleClass = new RectangleService();

            string[] values = value.Split(',');

            string msg = "";
            bool isValid = false;

            var res = rectangleClass.GetRectanglePointModel(values, out msg, out isValid);

            Assert.True(isValid);
            Assert.Equal("",msg);
            Assert.NotNull(res);
        }

        [Theory]
        [InlineData("2,2,2")]
        [InlineData("-2,4")]
        [InlineData("6,-4")]
        [InlineData("")]
        public void GetRectanglePointModel_False(string value)
        {
            rectangleClass = new RectangleService();

            string[] values = value.Split(',');

            string msg = "";
            bool isValid = false;

            var res = rectangleClass.GetRectanglePointModel(values, out msg, out isValid);

            Assert.False(isValid);
            Assert.Equal("Invalid Inputs:Please use top,left", msg);
            Assert.Null(res);
        }
      
    }
}