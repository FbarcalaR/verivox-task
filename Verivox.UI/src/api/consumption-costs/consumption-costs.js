const baseUrl = `${process.env.REACT_APP_API_HOST}/api`;
export async function getConsumptionCosts(kwhInput) {
    debugger
    const url = `${baseUrl}/consumption-costs?kwhConsumption=${kwhInput}`;
    try {
      const response = await fetch(url);
      if (!response.ok) {
        throw new Error(`Response status: ${response.status}`);
      }

      return Promise.resolve(response.json() ?? []);
    } catch (error) {
      console.error(error.message);
      return Promise.reject(error);
    }
  }
