#language: en
Feature: Bike management

	To handle a bike entity 
	As a employee of BikeCare
	I want to be able to register/open/update/remove bike information.

Background: 
	
	Given i am authenticated as employee '12345'
	And employee '12435' is authorized to register a new bike.
	

Scenario: Register new bike

	As an employee of BikeCare, I want to be able to register a bike for a customer
	
	When I register a new bike
	Then a new bike is registerd
	And the registration is available in the system