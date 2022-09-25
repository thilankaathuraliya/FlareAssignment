using Models;

namespace BusinessLayer
{
    public interface IRectangleService
    {
        List<RectangleModel> DeleteRectangle(List<RectangleModel> rectangleList, Point point, out bool isValid, out string msg);
        RectangleModel GetRectangle(List<RectangleModel> rectangleList, Point point);
        bool IsOverLapped(List<RectangleModel> rectangleList, RectangleModel rectangle);
        bool IsInside(RectangleModel rectangle1, RectangleModel rectangle2);
        bool IsValid(RectangleModel rectangle);
        bool DoOverLap(Point LeftTop1, Point BottomRight1, Point LEftTop2, Point BottomRight2);
        //  RectangleModel GetValidGrid();
        //  int GetValidateInput();
        RectangleModel GetRectangleModel(string[] values, out string message, out bool isValid);
        Point GetRectanglePointModel(string[] values, out string message, out bool isValid);
        RectangleModel GetGridModel(string[] values, out string message, out bool isValid);
    }
}
