﻿@ValidationGet_Berries_Endpoint
Feature: ValidationGet_Berries_Endpoint

Verify successful run of endpoint 'berry' (get 200 codes)

Scenario: Verify get 'berry' is successful
	When I try to call 'get berries' endpoint
	Then the response of 'get berries' endpoint will have successful code
	And the 'get berries' endpoint will return 20 berry models 
