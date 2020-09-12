# BusinessRulesEngine

This solution provides a real world working solution for a typical business rules engine. The focus was to create a rule engine which is not complex, provides enough freedom to the business rules to implement their own logic without tight coupling within businessrules.

The code is kept simple by calling methods to perform addintional actions such as printing packing slip, sending emails etc. This was not in scope. In real world each of these will have their own services which can be injected in the business rules they are required.
