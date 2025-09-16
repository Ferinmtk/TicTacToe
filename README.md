C# Tic-Tac-Toe Game
Project Overview

This project implements a console-based Tic-Tac-Toe game written in C#. The purpose of the module was to demonstrate understanding of the C# language, including variables, expressions, conditionals, loops, functions, classes, structures, and file I/O.

The program allows two players to take turns placing Xs and Os on a 3x3 board. The game detects winning conditions, draws, and invalid moves. A history of the moves can be written to and read from a file.

Features Implemented
Basic Requirements

Variables – used throughout for player moves, board state, and control flow.

Expressions – used in evaluating game rules and logic.

Conditionals – used in win and draw detection, as well as move validation.

Loops – used to repeatedly prompt for player input and update the board until the game ends.

Functions – modular functions for displaying the board, checking win conditions, and managing turns.

Classes – Player and TicTacToe classes were implemented to encapsulate behavior.

Structures – A struct was used to represent positions on the game board.

Complete working Tic-Tac-Toe game logic.

Additional Requirement

File I/O: The program demonstrates reading from and writing to a text file to store game history.

How to Run

Install .NET SDK
Clone this repository:
git clone https://github.com/Ferinmtk/TicTacToe.git
cd TicTacToe

Build and run the program:
dotnet run


Example Gameplay
Board:
 --- --- ---
|   |   |   |
 --- --- ---
|   |   |   |
 --- --- ---
|   |   |   |
 --- --- ---

Player 1 (X), enter your move (row and column 0-2):
Players alternate turns until a win or draw is declared.

Hours Spent

Total: 24 hours

Individual module: 14 hours

Other activities: 10 hours

Learning Strategies

Worked well: breaking the work into smaller tasks, testing incrementally, and referencing official documentation.

Did not work well: environment setup confusion (attempted to use bash in PowerShell).

Improvements: set up development environment properly at the beginning, and start documentation earlier in the sprint.