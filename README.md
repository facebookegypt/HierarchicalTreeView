# HierarchicalTreeView
Visual Basic .Net 2010 Example on TreeView and Microsoft Access 2007
This VB .NET 2010 Project explains how to populate a TreeView control with Data from Microsoft Access 2007 Database.
The Database example is USER Info
Database [hierarchical.accdb] has 3 tables
1) BasicInfo [Primary : CityID]
2) us_cities  [Primary : ID]
3) us_states  [Primary : ID_STATE]
three table are related through those primary keys.
In this example, I try to :
1) Use Module to create functions to validate OleDBConnect to the database
2) Create function to execute Sql Statement INSERT, UPDATE, SELECT, DELETE
3) Populate a combobox on main form with 29.8k data [City-State_code] using dictionary(Key,Value)
4) Insert,update,select,delete image to database and retrieve it to form picturebox control and TreeView Treenodes

<p>[Dependancies]
Microsoft Windows 32bit with .NET 4
Visual Studio 2010 or 2015
Microsoft Database Engine 2007
Administrator rights</p>
