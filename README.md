# PersonaliTune

## Introduction
This project is a proof of concept for a service that generates various insights based on personal Spotify data.
Its intended use is for the Betabit 2024 Q1 Deepdive AI session.

## Contents

### AzureOpenAI.Api
An api that serves as a wrapper for the Azure OpenAI service API. It is used to generate text based on a prompt.
It also contains prompt buildres that can be used to generate prompts for the api.
Finally, it serves as an abstraction for the interaction with the OpenAI API.

### Models
Contains the models used in the AzureOpenAIApi project and the UI project. 
In business projects, I would recommend using either NuGet for this, or duplicating the code, to be able to deploy all projects as separate services.

### Spotify.Api
An api that serves as a wrapper for the Spotify API. It is used to retrieve data from the Spotify API.

### UI
A simple Blazor UI that can be used to generate prompts and retrieve insights based on the AzureOpenAI.Api and Spotify.Api projects.
Refer to the "AI Assistent" page for the main functionality that needs to be expanded.

## Getting started
To get started, you need to create a Spotify app and an Azure OpenAI resource.
You can also use the already created resources, for which Jelle will share the necessary configuration.
Configuration needs to be added to the Api projects. 

The page that needs to be expanded is the AiAssistant.razor page in the UI project. 
The first two scenarios, the basic chat scenario and the simple prompt template (artist recommendation) scenario, 
are already available as examples.

Choose one of the following scenarios to expand on:

### Scenario A: Refactor the basic chat or artist recommendations
Refactor the basic chat so that the system prompt is not set in the UI.
Or try to tweak the system prompt so it gets better results.
Or refactor the artist recommendations to use better templates and decrease the chance of it recommending an artist you already listen to.
Or perhaps use the favourite tracks or the playlists of the user instead.

### Scenario B: Recommend an artist - international
Build two implementations: one where you interact with the Azure OpenAI API in the user's language,
and one where you translate the users input to English, then interact with the Azure OpenAI API, and then translate the output back to the user's language.
Try to determine which gives better results.

### Scenario C: Speak with the AI Assistant
Build an implementation where you interact with the Azure OpenAI API by speaking to it. 
Ideally, it should both speak back and write out all the input and output in text.

### Scenario D: Content Safety 
Build an implementation where you interact with the Azure OpenAI API to determine a "content safety" rating of a random song picked from your top 10 favourite songs.
The data (the artist, the lyrics, and the scores on the four categories of hate, violence, self-harm, and sexual content) should be treated as input for the LLM.
The LLM should write an essay that tries to still discover / inject suggestions of hate or violence in the lyrics and analyze them (if scores are safe / low), 
or provide lyrical alternatives that are more content safe (if the scores are medium / high).

### Scenario E: Discuss your personality
The AI assistant start discussing your personality and mood based on your musical taste. It allows counter questions and follow-up questions similar to the basic chat.

## Documentation
Set up your own Spotify project using https://developer.spotify.com/documentation/web-api/tutorials/getting-started#create-an-app
Spotify API docs: https://developer.spotify.com/documentation/web-api/
Azure Open AI docs: https://learn.microsoft.com/en-us/azure/ai-services/openai/
Translator docs: https://docs.microsoft.com/en-us/azure/cognitive-services/translator/translator-info-overview
Speech docs: https://docs.microsoft.com/en-us/azure/cognitive-services/speech-service/
Content Safety docs: https://learn.microsoft.com/en-us/azure/ai-services/content-safety/

