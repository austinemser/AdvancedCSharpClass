<h1>Events</h1>

* Mechanism for communication between objects
* used in building loosely coupled applications
* helps extending applications

{
	public void Encode(Video video)
	{
		// Encoding logic
		// ..

		_mailService.Send(new Mail());

		// In order to add this new messaging service we have to recompile the code
		_messageService.Send(new Text());
	}
}

<h2>Better paradigm</h2>
{
	public void Encode(Video video)
	{
		// Encoding logic
		// ..

		OnVideoEncoded();
	}
}

// Event Handler
public void OnVideoEncoded(object source, eventArgs e)

<h2>Delegates</h2>
* Agreement / Contract between Publisher and Subscriber
* Determines the signature of the event handler method in Subscriber

