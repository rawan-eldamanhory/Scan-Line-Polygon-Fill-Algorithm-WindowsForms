# Scan-Line Polygon Fill Algorithm

This project demonstrates the **scan-line polygon filling algorithm** using **C# and Windows Forms**.

The application draws a polygon and fills its interior with a specified color using the scan-line fill technique.

## 📌 Features
- Fills both convex and concave polygons
- Efficient horizontal line drawing
- Visualizes algorithm in real-time using Windows Forms

## 🧠 Algorithm Overview
The scan-line fill algorithm works by:
1. Determining the vertical extent (`minY` and `maxY`) of the polygon.
2. For each scan line (horizontal line) within this range:
   - Compute intersections with polygon edges
   - Sort the intersections by X coordinate
   - Fill pixels between each pair of intersections

## 🎨 Visualization
- Black outline: polygon edges
- Blue fill: filled region using scan-line algorithm

## 🛠️ Technologies Used
- C#
- .NET
- Windows Forms
- Graphics (GDI+)

## ▶️ How to Run
1. Open `WindowsFormsApp4.sln` in Visual Studio
2. Build and run the project
3. The polygon is automatically filled when the form is rendered

## 📄 License
Educational use only.
