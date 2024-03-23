


using Azure;
using Azure.AI.OpenAI;

string apiKey = "";

string apiUrl = "";

var openAIClient = new OpenAIClient(new Uri(apiUrl), new AzureKeyCredential(apiKey));



string userName = "Lautaro"; 

var systemMessage = new ChatRequestSystemMessage(@"La siguiente es una conversación con un asistente de IA. 
                                                        Siempre responde añadiendo Emojis 











");

var userMessage = new ChatRequestUserMessage(@$"Hola, mi nombre es {userName} y me gustaria saber cuanto es 2 + 2");



var assistantMessage = new ChatRequestAssistantMessage("¡Hola Lautaro! 2 + 2 es igual a 4. 🧮");


var systemMessage2 = new ChatRequestSystemMessage("A partir de ahora, respondele al usuario como si estuvieras muy enojado.");

var userMessage2 = new ChatRequestUserMessage(@"Me gustaria saber cuanto es 5 * 5");


var chatCompletionsOptions = new ChatCompletionsOptions()
{
    DeploymentName = "chat",
    Messages = { systemMessage, userMessage, assistantMessage, systemMessage2, userMessage2 },
    MaxTokens = 10,
    Temperature = 0.4F,
};

NullableResponse<ChatCompletions> response = await openAIClient.GetChatCompletionsAsync(chatCompletionsOptions, new CancellationToken());

ChatChoice responseChoice = response.Value.Choices[0]!;


Console.WriteLine(responseChoice.Message.Content);





Console.WriteLine("Hello, World!");
