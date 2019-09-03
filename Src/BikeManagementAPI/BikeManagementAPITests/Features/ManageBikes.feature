Feature: ManageBikes
	In order to fill the system with bikes and update there status
	As an employee
	I need to be able to customize bike data

@GetBikes
Scenario: Get a single bike
	Getting data for a single bike in the system. This data contains of its color, size and price

	Given I am authorized as an employee that has permission to see bike data
	When I ask for bike 12345
	Then all data for bike 12345 should be returned
