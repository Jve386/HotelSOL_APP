# RocketTeam-HotelSOL_APP

## Overview
This project focuses on .NET environment programming with access to distributed data, including SQL Server databases and native XML databases. The primary goal is to develop a room reservation management application with an information exchange system using Odoo, implemented in Java.

## Technologies Used
- .NET Ecosystem Components
- ADO.NET: Used for accessing and managing databases within .NET applications.
- ASP.NET: A web development framework facilitating the creation of web applications in the .NET environment.
- BCL (Base Class Library): A standard class library providing common functionalities for all .NET applications, simplifying development.
- C# Windows Forms: Employed for creating desktop applications on the Windows platform.

## Conclusions and Justification for Choices
- After thorough research and experimentation with various alternatives for connecting and manipulating XML data in .NET environments, we've reached essential conclusions and justified our choices.

- Use of System.Xml: The System.Xml library provides a solid foundation for working with XML data in .NET. It is user-friendly and supports basic read and write operations.

- Entity Framework Core for Advanced Manipulation: Entity Framework Core emerged as an excellent choice for advanced XML data manipulation. It offers an effective way to model and manipulate data through data models and queries, particularly beneficial for complex read and write operations.

- XmlReader and XmlTextWriter for Efficiency and Control: XmlReader and XmlTextWriter prove valuable when efficiently working with large XML files and requiring precise control over data read and write operations. These classes enable sequential data processing without loading the entire document into memory.

## Comparison of Components
The decision to use XmlReader and XmlTextWriter was made to efficiently work with XML data sources, particularly when dealing with large XML files. 

## Object-Relational Mapping (ORM) Used
Entity Framework Core

## UML DIAGRAM
![UML Diagram](diagramas/diagrama_de_clases.jpg)

## USE CASE
![use_case](diagramas/Casos_de_uso.jpg)
![use_case](diagramas/Casos_de_uso_admin.jpg)

## SEQUENCE DIAGRAM
![use_case](diagramas/secuencia.jpg)
