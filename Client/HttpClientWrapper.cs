namespace Jumpstart_MVC_Web_App.Client
{
    public class HttpClientWrapper
    {
        public static async Task<string> GetAsync(string uri)
        {
            string responseBody = string.Empty;
            using (HttpClient hc = new HttpClient())
            {
                try
                {
                    //await keyword handles all the complexity of async threading and callbacks
                    HttpResponseMessage response = await hc.GetAsync(uri);
                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        responseBody = await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        responseBody = "Request failed with status code: " + response.StatusCode;
                    }
                }
                catch(Exception ex)
                {
                    responseBody = "Request failed with error: " + ex.Message;
                }
            }

            return responseBody;
        }

        public static async Task<string> PostAsync(string uri, object data)
        {
            string responseContent = string.Empty;
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Convert the object to JSON
                    var json = System.Text.Json.JsonSerializer.Serialize(data);

                    // Create the content for the request
                    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    // Send the POST request
                    HttpResponseMessage response = await client.PostAsync(uri, content);

                    // Check if the request was successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content
                        responseContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Response: " + responseContent);
                    }
                    else
                    {
                        responseContent = "Request failed with status code: " + response.StatusCode;
                    }
                }
                catch (Exception ex)
                {
                    responseContent = "Request failed with error: " + ex.Message;
                }

                return responseContent;
            }
        }

        public static async Task<string> DeleteAsync(string uri)
        {
            string responseContent = string.Empty;
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Send the DELETE request
                    HttpResponseMessage response = await client.DeleteAsync(uri);

                    // Check if the request was successful
                    if (response.IsSuccessStatusCode)
                    {
                        responseContent = "Delete request succeeded";
                    }
                    else
                    {
                        responseContent = "Request failed with status code: " + response.StatusCode;
                    }
                }
                catch (Exception ex)
                {
                    responseContent = "Request failed with error: " + ex.Message;
                }

                return responseContent;
            }
        }

    }
}
