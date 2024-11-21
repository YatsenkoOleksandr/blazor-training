# Blazor Intro

- [Blazor Intro](#blazor-intro)
  - [How Blazor Works](#how-blazor-works)
  - [When to use Blazor](#when-to-use-blazor)
  - [Simple Blazor project structure](#simple-blazor-project-structure)
  - [Razor Component](#razor-component)
    - [Render C# expression values](#render-c-expression-values)
    - [Control flow](#control-flow)
    - [Event Handling](#event-handling)
    - [Data Binding](#data-binding)
    - [Interactivity](#interactivity)
  - [Hosting Models](#hosting-models)
  - [Interacting with data](#interacting-with-data)


Blazor is a framework based on HTML, CSS and C#.
Blazor helps to build web app using reusable components that can be run from both the client and server.

Blazor Benefits:

- Build UI fast with reusable components: Blazor encourages to use component model
- Add rich interactivity with C#: allows to handle arbitary UI events from the browser and implement component logic in C#
- One development stack: build web app using a single development stack and share code for common logic on the client and server
- Efficient diff-based rendering: Blazor tracks what parts of the DOM changed so that UI updates are fast and efficient
- Server and client-side rendering: Blazor allows to render components from both the server and client
- Progressively enhanced server rendering: Blazor provides built-in support for enhanced navigation and form handling
- Interop with JavaScript: allows to use the ecosystem of JavaScript libraries and browser APIs from C# code
- Web, mobile, desktop: Blazor components can also be used to build native mobile & desktop apps using a hybrid of native and web - Blazor Hybrid

## How Blazor Works

Blazor app is build from components. Blazor component is a reusable piece of web UI.
Component encapsulates both rendering and UI event handling logic.
Blazor includes built-in component for form handling, user input validation, authentication & authorization.

Blazor components are written using Razor syntax. A Razor file contains plain HTML and then C# to define any rendering logic (conditionals, control flow, expression evaluation).
Razor file is compiled into C# class.

Blazor supports both serber and client-side rendering.
Components rendered from server can access server resources.
By default, Blazor components are rendered statically from the server, generating HTML in response to requests

Server components could be configured to be interactive. Interactive server component handles UI interactions and updates over a WebSocket connection with the browser.

Alternatively, Blazor component can be rendered interactively from the client. The component is downloaded to the client and run from the browser via WebAssembly.
Interactive WebAssembly component can access client resources like local storage, and can even function offline once downloaded.

## When to use Blazor

When to consider Blazor for web development:

- looking for a highly productive full stack web development solution
- need to deliver web app quickly without the need for separate frontend development team
- already using .NET and want to apply existing .NET skills and resources on the web
- need high-performance and highly scalable backend to power web app

Blazor is not good if:

- need to fully optimize download size and load time of client-side assets
- need to integrate heaviliy with a different frontend framework ecosystem
- need to support older web browsers

## Simple Blazor project structure

- `Program.cs` - entry point for the app that starts the server and the place to configure app service and middleware
- `App.razor` - root component for the app
- `Routes.razor` - configures Blazor router
- `Components/Pages` - contains example web pages and components

## Razor Component

`@page` directive specifies the route for the page

`<PageTitle/>` tag is Blazor component that sets the title for the current page

To use another component just add a component tag (e.g. `<MyButton />`).

Components can also have parameters, which allow you to pass data to the component when it's used.
Component parameters are defined by adding a public C# property to the component that also has a `[Parameter]` attribute.
You can then specify a value for a component parameter using an HTML-style attribute that matches the property name.
The value of the parameter can be any C# expression.

```
@code {
 [Parameter]
 public int IncrementAmount { get; set; } = 1;
 ...
}

...
<Counter IncrementAmount="10"/>
```

The `@code` block in a Razor file is used to add C# class members (fields, properties, and methods) to a component.
You can use the `@code` to keep track of component state, add component parameters, implement component lifecycle events, and define event handlers.

### Render C# expression values

To evaluate C# expression in Razor use a leading `@` character:

```
<p role="status">Current count: @currentCount</p>
```

### Control flow

If-statement control flow:

```
@if (currentCount > 3)
{
    <p>You win!</p>
}
```

Loop over data:

```
<ul>
    @foreach (var item in items)
    {
        <li>@item.Name</li>
    }
</ul>
```

Blazor includes other looping directives, such as `@for`, `@while`, and `@do while`.
These directives return repeated blocks of markup.
They work in a similar way to the equivalent C# `for`, `while`, and `do...while` loops.

### Event Handling

To specify an event handler use an attribute that starts with `@on` and ends with event name:

```
<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>
```

Event handlers could be defined as lambda expression:

```
<button class="btn btn-primary" @onclick="() => currentCount++">Click me</button>
```

Event handler can optionally take an event argument:

```
<input @onchange="InputChanged" />
<p>@message</p>

@code {
    string message = "";

    void InputChanged(ChangeEventArgs e)
    {
        message = (string)e.Value;
    }
}
```

Event handlers can be asynchronous.

### Data Binding

Blazor provides ability to bind the value of UI element to a particular value.
When the value of the UI element changes, the code value should change as well, and vice verse.
Blazor provides two-way data binding using `@bind` attribute:

```
<input @bind="text" />
<buttin @onclick="() => text = string.Empty">Clear</button>
<p>@text</p>

@code {
    string text = "";
}
```

### Interactivity

To handle UI events from a component and to use data binding, the component must be **interactive**.
By default, Blazor components render statically from the server: they generate HTML in response to requests.

To make a component interactive need to apply render mode using `@rendermode` directive.

Render mode applied to a component definition:

```
@rendermode InteractiveServer
```

Render mode applied to a component instance:

```
<Counter @rendermode="InteractiveServer" />
```

Interactive server rendering handles UI events from the server over a WebSocket connection with the browser.
Blazor sends UI events to the server over this connection so that the app's components can handle them.
Blazor then handles updating the browser DOM with the rendered updates.

Alternatively, Blazor components can use the `InteractiveWebAssembly` render mode to render interactively from the client.
In this mode, the component code is downloaded to the browser and run client-side using a WebAssembly-based .NET runtime.

## Hosting Models

1. **Blazor Server**

   In this model, the app is executed on the web server within an ASP.NET Core app.
   UI updates, events, and JavaScript calls on the client side are sent through a SingalR connection between the client and the server.
2. **Blazor WebAssembly**

   In this model, the Blazor app, its dependencies, and the .NET runtime are downloaded and run on the browser.

## Interacting with data

In a Blazor Server app, you can create a registered service to represent a data source and obtain data from it.
The sources of data you can use in a Blazor app include relational databases, NoSQL databases, web services, various Azure services, and many other systems.

Before you can call the service from the component, you must use dependency injection to add the service. Inject the service by adding the following code after the `@page` directive:

```
@using BlazingPizza.Data
@inject PizzaService PizzaSvc
```

`@using` directive works in the same way as `using` statement at the top of a C# code file.

`@inject` directive adds the service to the current component and initiates an instance of it.
In the directive need to specify the service class name, and the instance name of the service inside the component:

```
@using [Service Class Name] [local variable name]
```

`OnInitializedAsync` event fires when component's initialization is completed and it has received initial parameters, but before the page is rendered and displayed to the user.
This method is a good place to fetch the data.

```
protected override async Task OnInitializedAsync()
{
    // Call the service here
}
```
