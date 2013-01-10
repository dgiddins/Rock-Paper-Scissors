Feature: PlayRockPaperScissorsAgainstComputer
	In order to have fun
	As a time waster
	I want to play rock paper scissors agains the computer


Scenario: I play rock computer plays scissors
	Given 'Player1' plays rock
	And the computer will play scissors
	When we show weapon
	Then 'Player1' wins
	And the outcome is described as 'Scissors beats rock, Player1 wins!'
