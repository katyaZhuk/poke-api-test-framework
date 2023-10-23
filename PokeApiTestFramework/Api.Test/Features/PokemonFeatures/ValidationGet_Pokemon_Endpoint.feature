@ValidationGet_Pokemon_Endpoint
Feature: ValidationGet_Pokemon_Endpoint

Verify successful run of endpoint 'pokemon' (get 200 codes)

Scenario: Verify get 'pokemon' is successful
	When I try to call 'get pokemons' endpoint
	Then the response of 'get pokemons' endpoint will have successful code
	And the 'get pokemons' endpoint will return 20 pokemon models 
