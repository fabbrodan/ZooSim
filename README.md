## ZooSim

The main Domain Model project.
Utilizing [ConsoleSimulationEngine200](https://github.com/mattiasnordqvist/ConsoleSimulationEngine2000) as the base for GUI and input.

The model contains the following entities:

* Animals
	* Elephant
	* Monkey
	* Penguin

* Zoo
	* Account

**Version: Alpha 0.0.1.1**
- [X] Interest of Loans
- [ ] Animals generating money
- [ ] Death by age

## ZooConsole

The output window wich consumes the Domain.
Command and input logic stored here

Here we are utiizing the Command Design Pattern to agnostically handle user input and easily add aditonal ones if needed.


**Version: Alpha 0.0.1.1**
Only supports single-worded names for animals


## ZooTest
Test project for domain model.
