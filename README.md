# WorkTrackr  
**Team Task Management & Agile Progress Tracker**

---

## 🧠 Project Overview

WorkTrackr is a lightweight, console-based productivity tool designed to help small teams manage tasks collaboratively.  
It enables users to create, assign, and track tasks, set priorities and deadlines, and monitor project progress through an Agile workflow — all within a fast and user-friendly console application.

---

## 💼 Business Problem

Small teams often lack affordable, simple task management tools. Popular platforms are either too complex or too expensive.  
WorkTrackr addresses this by providing a streamlined Agile task management experience in a **C# console application**, with only essential features that support real teamwork.

---

## ✅ Completed Features

- Console-based **Main Menu** with full options: View, Create, Edit, Delete, Assign, Update, Dashboard, Exit
  - Edit existing tasks (update title, description, priority)
  - Delete tasks with confirmation prompt
- Create task feature:
  - Title, description, due date, priority (1 = Low, 2 = Medium, 3 = High)
  - Status defaults to **Backlog**
  - Due date input options: 1 week, 2 weeks, or custom (yyyy-mm-dd)
  - Validation for past/future dates and correct formats
- View tasks with color-coded statuses:
  - Backlog: Gray
  - In Progress: Yellow
  - In Review: Blue
  - Completed: Green
- Add and View users
- Assign task to user
- Update task status using 1/2/3/4 input
- View dashboard with task counts by status and priority (LINQ-based)
- All data held in memory using `List<T>`
- Refactored for clean, readable input handling
- `.gitignore` and initial README

---

## 🛠️ Technologies Used

- **C# (.NET 8 LTS Console Application)**
- **Visual Studio 2022**
- **GitHub** (Version Control & Collaboration)
- Agile development workflow (task board, roles, commits)

---

## 🎯 Learning Objectives

- Build a functional C# console application from scratch
- Apply Agile principles to real development (task assignments, status tracking)
- Practice core C# concepts:
  - Classes, objects, and constructors
  - Collections (List<T>)
  - Control flow (switch, if, loops)
  - LINQ queries
  - Exception handling & validation
- Use GitHub for version control and collaboration

---

## 🔁 How It Works (User Flow)

1. User launches app → sees **Main Menu**
2. User can:
   - View all tasks
   - Create new task
   - Add a new user
   - Assign task to user
   - Update task status
   - Edit or delete existing tasks
   - View dashboard (summary)
   - Exit application
3. Inputs are validated
4. Program responds with clear output for all operations

---

## 👥 Team Members

| Name                  | Student Number |
|-----------------------|----------------|
| Aditya Singh Bhandari | A00287516      |
| Lalitha Mirthipati    | A00299457      |
| Pinto Andara          | A00315058      |
| Abhishek Chauhan      | A00320017      |

---

## 📋 Agile Task Board (Progress Tracker)

### ✅ Completed
- Project structure created (Aditya)
- Program.cs with Main Menu added (Aditya)
- Task.cs, User.cs, TaskManager.cs created (Aditya)
- CreateTask logic (Aditya)
- ViewAllTasks logic (Aditya)
- Priority & due date validation using input options (Aditya)
- AssignTask, AddUser, and UpdateTaskStatus methods (Lalitha, Pinto)
- Refactored and cleaned logic for user input (Aditya)
- `.gitignore` + initial README (Aditya)
- Add sample data (Abhishek)
- Add/Edit/Delete tasks (Abhishek)
- EditTask and DeleteTask methods integrated into UI (Aditya)
- Fixed Build Error associated with TaskManager (Pinto)
- Dashboard implemented with LINQ (Pinto)


### 🔄 In Progress
- 


### ⏳ Backlog (Not Started)
- Add task comments
- Save/load from file (optional)

---

## 💻 Console UI Mockup

=== WorkTrackr Main Menu ===
1. View All Tasks
2. Create New Task
3. Add New User
4. Assign Task to User
5. Update Task Status
6. Edit Task
7. Delete Task
8. View Dashboard
9. Exit
    
Select an option:     




