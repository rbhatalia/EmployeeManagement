# Employee Management Solution

[[_TOC]]

## Feature Included

+ List
+ Filtered Search
+ Edit record inline
+ Delete record

## Future scope features

+ Add
+ Export
+ Improve logging
+ Pagination implementation
+ Improve test case scenarios

## Technical Considerations

+ Use dependency injection design pattern
+ Use CQRS pattern
+ Environment variables injected from appsettings.json file
+ Separate business logic from action handler class
+ Log into console for now

## Description

The landing page has an inline editable table. Above it action controls,

+ Search Textbox and Search Button
+ Clear Button
+ Delete Button

### List

On launch of the application, user will be able to see a list of records in a table

### Edit

The table on the screen, has editable cells, the user needs to,

+ Double click on any cell
+ Update the value
+ Move out of the cell to save the record

### Filter

Above the grid, there is a textbox where the user needs to type text and click on Search, to filter records at server side

### Clear Filter

Above the grid, there is a clear button, which clears the textbox and reloads the default search results

### Delete

Above the grid, at the right end there is Delete button, user needs to select a row from the table and click on delete to delete the record
