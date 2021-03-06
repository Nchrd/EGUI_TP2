# [EGUI] TP2 - ASP.NET MVC

## Task 2: Blog application in ASP.MVC
- Please write simple Blog Application using ASP.MVC (under linux - should work on CS101 lab computer) - using .net core 6.0
- Data should be stored in text files (in \*.json format) in selected folder on the server
- Please use Bootstrap for GUI design

## Setup Instructions
- Please first check your NuGet Packages to able to generate the solution
- Packages required :
  - EntityFramework (v 6.4.4)
  - Microsoft.AspNetCore.Session (v 2.2.0)
  - Microsoft.EntityFrameworkCore (v6.0.4)
  - Microsoft.EntityFrameworkCore.Sql (v 6.0.4)
  - Microsoft.EntityFrameworkCore.Tools (v 6.0.4)
  - Microsoft.jQuery.Unobtrusive.Validation (v 3.2.12)
  - Microsoft.VisualStudio.Web.CodeGeneration (v6.0.3) (not mandatory but recommended to edit a project easily in a general way)
  - System.Configuration.ConfigurationManager (v 6.0.0)
  - System.Data.SqlClient (v 4.8.3)
  - Swashbuckle.AspNetCore (v 6.3.1)
- You also need to create a database to store data (Microsoft SQL Server Management Studio is recommended for the setup)
- Configuration process :
  - Thanks to MSSMS create an empty database after connecting to your local SQL Server.
  - In Visual Studio get the Connection string of the database from the SQL Object Explorer
  - In AppSetting.json, App.Config and Web.Config change the "connectionString" field with your new connection string

### Application should store:
- for the users:
  - userId - unique user id - text obtained from the user during user registration
  - email - e-mail address of the user
  - password - password provided by the user
- for the blogs:
  - id - unique blog identifier (text, provided by the blog creator) 
  - title - blog title
  - ownerId - id of the blog owner (creator of the blog)
  - list of items: for each of them
    - title: one line of text
    - id: userID of the publishing author
    - datetime: exact time of publication (set automatically from the system time)
    - content: content of the publication

Blog data should be stored in *.json files!

### Application should enable:
- user registration
- login for registered users
- after login:
  - display list of the blogs
  - creation of the new blog
  - delete of the blog (only blog created by me)
  - display content of the selected blog
    - title
    - id of the owner
    - list of blog entries:
      - id of entry publisher
      - date/time of publication
      - title/content
  - after selecting a blog user may:
    - add new entry in the blog
    - delete own entry from the blog
    - modify own entry in the blog

### Application should contains following views (windows/dialogs)
- login view
- registration view
- list of blogs view
- single blog view
- entry add/edit/create view

### Important
The most important part of the task is to make sure the user interface behaves correctly, e.g.:
- You cannot create a user without an id or with id similar to an existing one
- You cannot confirm creating a blog entry if not all mandatory data is filled in
- If list of entries is empty, "remove" button is disabled
- Data is edited using widgets appropriate for that data type
- Regular desktop application look and feel is maintained (e.g. toolbars, menus, item selection)
- Resizing windows does not cause content to disappear or unused empty space to appear in the window
- Code quality is considered during evaluation
