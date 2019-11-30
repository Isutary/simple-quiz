# simple-quiz
Simple quiz app

Just create your custom **List\<Question\>** *question*, in **Question** class **int** *CorrectAnswer* is index at which correct asnwer 
is found within *Answers*. Th first parameter in **Quiz** is **List<Question>**, second parameter in **Quiz** constructor is the number of 
questions to be asked from *AllQuestions*.
Multiple clicks will not be tolerated, quiz skips questions if more than one click is issued before the next question is shown.
A simple fix would have been to disable and enable buttons, but then they look ugly and I didn't want to draw them manually.
