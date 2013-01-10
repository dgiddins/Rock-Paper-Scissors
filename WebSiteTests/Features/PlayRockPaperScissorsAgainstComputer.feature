Feature: PlayRockPaperScissorsAgainstComputer
	In order to have fun
	As a time waster
	I want to play rock paper scissors agains the computer


Scenario: I play rock computer plays scissors
	Given 'Player1' plays 'rock'
	And the computer will play 'scissors'
	When we show weapon
	Then 'Player1' wins
	Then 'Computer' loses
	And the outcome is described as 'rock beats scissors, Player1 wins!'

Scenario: I play rock computer plays paper
	Given 'Player1' plays 'rock'
	And the computer will play 'paper'
	When we show weapon
	Then 'Computer' wins
	Then 'Player1' loses
	And the outcome is described as 'paper beats rock, Computer wins!'
		
Scenario: I play rock computer plays rock
	Given 'Player1' plays 'rock'
	And the computer will play 'rock'
	When we show weapon
	Then there is a draw
	And the outcome is described as 'Draw, what are the odds!'

Scenario: I play scissors computer plays paper
	Given 'Player1' plays 'scissors'
	And the computer will play 'paper'
	When we show weapon
	Then 'Player1' wins
	Then 'Computer' loses
	And the outcome is described as 'scissors beats paper, Player1 wins!'

Scenario: I play scissors computer plays rock
	Given 'Player1' plays 'scissors'
	And the computer will play 'rock'
	When we show weapon
	Then 'Computer' wins
	Then 'Player1' loses
	And the outcome is described as 'rock beats scissors, Computer wins!'

Scenario: I play scissors computer plays scissors
	Given 'Player1' plays 'scissors'
	And the computer will play 'scissors'
	When we show weapon
	Then there is a draw
	And the outcome is described as 'Draw, what are the odds!'

	
Scenario: I play paper computer plays rock
	Given 'Player1' plays 'paper'
	And the computer will play 'rock'
	When we show weapon
	Then 'Player1' wins
	Then 'Computer' loses
	And the outcome is described as 'paper beats rock, Player1 wins!'

Scenario: I play paper computer plays scissors
	Given 'Player1' plays 'paper'
	And the computer will play 'scissors'
	When we show weapon
	Then 'Computer' wins
	Then 'Player1' loses
	And the outcome is described as 'scissors beats paper, Computer wins!'

Scenario: I play paper computer plays paper
	Given 'Player1' plays 'paper'
	And the computer will play 'paper'
	When we show weapon
	Then there is a draw
	And the outcome is described as 'Draw, what are the odds!'