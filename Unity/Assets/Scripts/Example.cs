// To declare (write) write the "class" keyword followed by the name.
// Usually the class name is the same as the script/file name.
class Example
// "class" is the keyword
// "Example" is the class name

{ // Opening body tag (class)

// To add anything to the class, it must be added between the opening & closing body tag
// The body tags encapsulates the code that belongs to the class.


// To declare a function|method we need to write the data return type and provide a name
// void means return nothing, no data is returned from the class
// Following the function name we write () round brackets where you can choose to pass in data
	void ReturnNothingFunction() { // Opening body tag (function)
		// This function takes no data & returns no data
	} // Closing body tag (function)

	// a bool is a data type that can either be True | False
	bool ReturnTrueOrFalseFunction() { // Opening body tag (function)
		// This is a function that MUST return either True or False
		// If no data is return, this is critical error, and the code won't compile

		// We have decided to return True
		return true;
	} // Closing body tag (function)

	// a int hold a whole number e.g. no decimal places
	int ReturnInt() {
		return 1;
	}
	
	// A float hold faction numbers e.g. can have a decimal place

	float ReturnFloat() {
		return 0.1f;
	}
	
	// Passing data into a function
	void PassDataIntoFunction(bool value) {
		// Since it's a void, we don't need to return any data
		// We can now use / access "value" which is a bool being passed into the function
		value = true;
	}

	void IfStatement(bool value) {
		
		// To write an if statement start with the keyword "if"
		// followed by round brackets with contain a condition
		// followed by body tags which encapsulate code belonging to the if statement

		if (true) {
			
		}
	}
	
} // Closing body tag (class)