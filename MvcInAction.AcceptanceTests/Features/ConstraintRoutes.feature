Feature: ConstraintRoutes feature
	In order verify the routes for Constraint Controller are right
	As an User
	I want to verify the routes are handled correctly

Scenario: Verify Route with Constraint
	Given I have entered "~/Constraint/1" as url pattern
	When I hit enter
	Then the controller should be "Constraint"
	And the action should be "Constraint"
	And the id should be "1"

Scenario: Verify Route without Constraint
	Given I have entered "~/Constraint/Miguel" as url pattern
	When I hit enter
	Then the controller should be "Constraint"
	And the action should be "NoConstraint"
	And the id should be "Miguel"