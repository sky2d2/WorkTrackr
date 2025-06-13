# WorkTrackr
**Team Task Management & Agile Progress Tracker**

---

## Project Overview

WorkTrackr is a lightweight, console-based productivity tool designed to help small teams manage tasks collaboratively.  
It enables users to create, assign, and track tasks, set priorities and deadlines, and monitor project progress through an Agile workflow — all within a simple, fast console application.

---

## Business Problem

Small teams often lack affordable, easy-to-use task management systems. Many existing tools are either too complex or too expensive.  
WorkTrackr addresses this by providing a streamlined Agile task management experience in a **simple C# console application**, with clear features focused on real team needs.

---

## ✅ Current Features (Completed)

- Console-based **Main Menu** with working options (View, Create, Exit)
- Create task feature includes:
  - Title, description, due date, priority (1 = Low, 2 = Medium, 3 = High)
  - Status defaults to **Backlog**
  - Input validation: rejects invalid dates and past due dates
- View all tasks in clean formatted output
- All tasks stored in memory using `List<Task>`
- **.gitignore** added for clean repository structure

---

## 🚀 Planned Features (Next Steps)

- Assign tasks to users
- Add/edit/delete tasks
- Update task status (In Progress, In Review, Completed)
- Add comments to tasks
- Enhanced dashboard using LINQ
- Save/load task data (optional)
- Add sample/test data for demo

---

## 🎯 Objectives

- Provide an easy-to-use task management system for small teams
- Implement Agile workflow concepts in a console application
- Help teams stay organized and track project progress
- Practice key C# concepts:
  - Classes and objects
  - Methods and control flow
  - Collections (List<>)
  - LINQ queries and filtering
  - Exception handling and input validation

---

## 🔁 How It Works (Current Flow)

1. User launches WorkTrackr → Main Menu is displayed
2. User can:
   - View all tasks
   - Create a new task
   - Exit the application
3. Each task contains:
   - Title, Description, Priority, Due Date, Status
4. Tasks default to “Backlog” status
5. Input is validated for correctness and date formatting

---

## 🛠️ Technologies Used

- **C# (.NET 8 LTS Console Application)** → current supported version (2025)
- **Visual Studio 2022**
- **GitHub** (version control + collaboration)
- Agile methodologies (task board, team roles, commits)

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
- Task.cs added (Aditya)
- User.cs added (Aditya)
- TaskManager.cs added (Aditya)
- CreateTask method with validation (Aditya)
- ViewAllTasks logic implemented (Aditya)
- Date & priority validation added (Aditya)
- .gitignore added (Aditya)
- Initial README.md created (Aditya)

### 🔄 In Progress
- [To be updated as new features are implemented]

### ⏳ Backlog (Not Started)
- Assign task logic (Lalitha)
- Add/edit/delete tasks (Abhishek)
- Dashboard and LINQ queries (Pinto)
- Add user logic (Lalitha)
- Update task status logic (Pinto)
- Add comments (TBD)
- Add sample data (Abhishek)

---

## 💻 Console UI Mockup

=== WorkTrackr Main Menu ===

1. View All Tasks
2. Create New Task
3. Add New User
4. Assign Task to User
5. Update Task Status
6. View Dashboard
7. Exit

Select an option:





