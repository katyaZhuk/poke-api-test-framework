@ValidationGet_Pokemon_Name_Endpoint
Feature: ValidationGet_Pokemon_Name_Endpoint

Verify successful run of endpoint 'pokemon/{name}' (get 200 codes)

Scenario: Verify get 'pokemon/{name}' is successful
	When I try to call 'get pokemon/{name}' endpoint with '<name>' name
	#Then the response of 'get pokemon/{name}' endpoint will have successful code
	#And the response of 'get pokemon/{name}' endpoint will contain correct pokemon model

Examples: 
	| name      |
	| pikachu   |
	| bulbasaur |
	| meowth    |
