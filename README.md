# simple-quiz
Simple quiz app

Just create your custom **List\<Question\>** *question* and pass it to **Quiz**. In **Question** class **int** *CorrectAnswer* is 
index at which correct answer is found within *Answers*. The first parameter in **Quiz** is **List\<Question\>**, second parameter is the number of questions to be asked from *AllQuestions*.
Multiple clicks will not be tolerated, quiz skips questions if more than one click is issued before the next question is shown.
A simple fix would have been to disable and enable buttons, but then they look ugly and I didn't want to draw them manually.
