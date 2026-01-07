# Day-3 Array Operations - C# Console Application

**Author:** Mohamed Khaled Tawfeek  
**Email:** mohamed.ibraham98@gmail.com  
**Course:** ITI Intensive Code Camp 2025-2026 R2, Full Stack .NET, Zagazig  
**Language:** C#  

---

## Overview

This C# console application demonstrates array operations for **one-dimensional** and **two-dimensional arrays**.  
It is designed as part of the Day-3 exercises in the ITI Full Stack .NET program.

The application allows the user to:

- Perform **One-Dimensional Array Operations**:
  - Input array elements
  - Compute **sum**, **minimum**, and **maximum** values

- Perform **Two-Dimensional Array Operations**:
  - Input student grades (3 students × 3 subjects)
  - Compute **row-wise sum, minimum, and maximum**
  - Compute **column-wise averages**
  - Display results in a tabular format

Input validation is implemented using **regex** to ensure only numeric integers (positive or negative) are accepted.

---

## Features

1. **Menu-driven interface**
   - User-friendly console menu
   - Options for 1D and 2D array operations
   - Exit program with the ESC key

2. **Input validation**
   - Uses regular expressions to ensure numeric input
   - Handles empty or invalid input gracefully

3. **1D Array Operations**
   - Calculates sum, min, max
   - Displays results clearly

4. **2D Array Operations**
   - Handles a 3×3 matrix of student grades
   - Calculates row-wise sum, min, max
   - Calculates column-wise averages
   - Displays results in tables for clarity

---

## Usage

1. Clone the repository:

```bash
git clone https://github.com/MoOps-dev/ITI-Day-3.git
```

2. Open the project in **Visual Studio** or **VS Code**.

3. Build and run the project.

4. Follow the menu prompts:

- Press `1` for one-dimensional array operations.
- Press `2` for two-dimensional array operations.
- Press `ESC` to exit the program.

---

## Example Screenshots

**Menu:**
```
*******************************************************
*** Welcome to Day-3, Choose an action to continue: ***
*******************************************************
** 1. One Dimension Array Operations                **
** 2. Two Dimension Array Operations.               **
** Or press ESC to exit the program.                **
*******************************************************
```

**One-Dimensional Array Output:**
```
Array Sum = 45
Array Min = 5
Array Max = 15
```

**Two-Dimensional Array Output:**
```
******** Degree1 - Degree2 - Degree3 ********
Student1   80  90  70
Student2   60  85  75
Student3   95  88  92

************** SUM - MIN - MAX **************
Student1   240 70  90
Student2   220 60  85
Student3   275 88  95

**** Average:Degree1 - Degree2 - Degree3 ****
Average    78  87  79
```

---

## Technologies

- **C#** - .NET 6 / 7 (Console Application)
- **Regex** - Input validation
- **Console Tables** - Simple tabular output

---

## License

This project is **for educational purposes**. Feel free to modify and use it for learning C# array operations.

