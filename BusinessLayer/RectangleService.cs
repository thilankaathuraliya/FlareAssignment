using Models;


namespace BusinessLayer
{
    public class RectangleService : IRectangleService
    {
        public List<RectangleModel> DeleteRectangle(List<RectangleModel> rectangleList, Point point, out bool isValid, out string msg)
        {
            RectangleModel model = rectangleList.Find(x => x.TopCoordinate.X < point.X && x.RightBottomCoordinate.Y > point.X && x.TopCoordinate.Y < point.Y && x.RightBottomCoordinate.Y > point.Y);
            if (model != null)
            {
                rectangleList.Remove(model);
                isValid = true;
                msg = "Rectangle Deleted";
               

            }
            else
            {
                isValid = false;
                msg = "Rectangle Not Found";
            }

            return rectangleList;
        }
        public RectangleModel GetRectangle(List<RectangleModel> rectangleList, Point point)
        {
            RectangleModel model = rectangleList.Find(x => x.TopCoordinate.X < point.X && x.RightBottomCoordinate.Y > point.X && x.TopCoordinate.Y < point.Y && x.RightBottomCoordinate.Y > point.Y);
            return model;
        }
        public bool IsOverLapped(List<RectangleModel> rectangleList, RectangleModel rectangle)
        {
            foreach (RectangleModel item in rectangleList)
            {
                bool isOverlap = DoOverLap(rectangle.TopCoordinate, rectangle.RightBottomCoordinate, item.TopCoordinate, item.RightBottomCoordinate);
                if (isOverlap)
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsInside(RectangleModel rectangle1, RectangleModel rectangle2)
        {
            if ((rectangle2.Top + rectangle2.Width) <= rectangle1.Width && rectangle2.Top + rectangle2.Height < rectangle1.Height)
            {

                return true;
            }
            else
            {
                return false;
            }

        }
        public bool IsValid(RectangleModel rectangle)
        {
            if (rectangle.Top < 0 || rectangle.Left < 0 || rectangle.Height < 0 || rectangle.Width < 0)
            {
                return false;
            }
            else if(rectangle.Height==0 || rectangle.Width==0)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }
        public bool DoOverLap(Point LeftTop1, Point BottomRight1, Point LeftTop2, Point BottomRight2)
        {
            // if rectangle has area 0, no overlap

            if (LeftTop1.X == BottomRight1.X || LeftTop1.Y == BottomRight1.Y || BottomRight2.X == LeftTop2.X || LeftTop2.Y == BottomRight2.Y)
            {
                return false;
            }
            //// If one rectangle is on left side of other 

            if (LeftTop1.X >= BottomRight2.X || LeftTop2.X >= BottomRight1.X)
            {
                return false;
            }
            //// If one rectangle is above other 

            if (BottomRight1.Y <= LeftTop2.Y || BottomRight2.Y <= LeftTop1.Y)
            {
                return false;
            }

            return true;

        }
        public RectangleModel GetGridModel(string[] values, out string message, out bool isValid)
        {
            // isValid = false;
            message = "";
            RectangleModel model = new RectangleModel();
            if (values.Length == 2)
            {
                if (int.TryParse(values[0], out int width) && width >= 5 && width <= 25 && int.TryParse(values[1], out int height) && height >= 5 && height <= 25)
                {
                    isValid = true;
                    model.Width = width;
                    model.Height = height;
                }
                else
                {
                    isValid = false;
                    message = "Invalid Inputs:Please use width,height";
                    model = null;
                }
            }
            else
            {
                isValid = false;
                message = "Invalid Inputs:Please use width,height";
                model = null;
            }

            return model;
        }
        public RectangleModel GetRectangleModel(string[] values, out string message, out bool isValid)
        {
            // isValid = false;
            message = "";
            RectangleModel model = new RectangleModel();
            if (values.Length == 4)
            {
                if ((int.TryParse(values[0], out int top) && top >= 0) && int.TryParse(values[1], out int left) && left >= 0
                    && int.TryParse(values[2], out int width) && width >= 0
                    && int.TryParse(values[3], out int height) && height >= 0)
                {
                    isValid = true;
                    model.Top = top;
                    model.Left = left;
                    model.Width = width;
                    model.Height = height;
                }
                else
                {
                    isValid = false;
                    message = "Invalid Inputs:Please use top,left,width,height";
                    model = null;
                }
            }
            else
            {
                isValid = false;
                message = "Invalid Inputs:Please use top,left,width,height";
                model = null;
            }

            return model;
        }

        public Point GetRectanglePointModel(string[] values, out string message, out bool isValid)
        {
            //isValid = false;
            message = "";
            Point model = new Point();
            if (values.Length == 2)
            {
                //  int top = 0, left = 0;

                if ((int.TryParse(values[0], out int top) && top >= 0) && int.TryParse(values[1], out int left) && left >= 0)
                {
                    isValid = true;
                    model.X = top;
                    model.Y = left;

                }
                else
                {
                    isValid = false;
                    message = "Invalid Inputs:Please use top,left";
                    model = null;
                }
            }
            else
            {
                isValid = false;
                message = "Invalid Inputs:Please use top,left";
                model = null;
            }

            return model;
        }
    }
}
