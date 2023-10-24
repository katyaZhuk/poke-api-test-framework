@ValidationGet_Pokemon_Name_Endpoint
Feature: ValidationGet_Pokemon_Name_Endpoint

Verify successful run of endpoint 'pokemon/{name}' (get 200 codes)
Verify error message when name is incorrect (get 404 codes)

Scenario: Verify get 'pokemon/{name}' is successful
	When I try to call 'get pokemon/{name}' endpoint with '<name>' name
	Then the response of 'get pokemon/{name}' endpoint 'should' have successful code
	And the response of 'get pokemon/{name}' endpoint should contain correct '<name>' model

Examples: 
	| name      |
	| pikachu   |
	| bulbasaur |
	| meowth    |

Scenario: Verify get 'pokemon/{name}' has error message when name is incorrect
	When I try to call 'get pokemon/{name}' endpoint with incorrect name
	Then the response of 'get pokemon/{name}' endpoint 'should not' have successful code
