# Access SQL Query Tool

## What
Fast and simple utility to paste MS Access SQL query, run it, and see time it took to run and, in case of error, more detailed message.

## Why
Needed to solve a problem when MS Access (Version 2021 at the time of the writing) displays poor messaging when it comes to report an error in the (usually complicated) query. 

It takes some time to figure out if closing bracket is missing on one of the JOINs 
or possibly some function has been given wrong number of parameters - yes, it happens to those who still write SQL queries by hand ;).

## Technologies
- C# using Microsoft Visual Studio Community 2022 (64-bit) 
- NETCore (.Net 8 LTS at the time of the writing)
- Windows Forms

## Dependencies
- Microsoft.Extensions.Configuration.Json to handle settings in Json format (appsetting.json)
- Newtonsoft.Json to load and update Json settings 
- System.Data.OleDb to connect and query MS Access Database

## References
- Sample MS Access database created using data from [here](https://github.com/awhstin/Dataset-List/blob/master/presidents.csv).

