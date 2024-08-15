import "./consumption-costs.css";
import { useEffect, useState } from "react";
import ConsumptionCostInfo from "./consumption-costs-list/consumption-costs-list";
import { getConsumptionCosts } from "../../api/consumption-costs/consumption-costs";

function ConsumptionCosts() {
  let [kwhInput, setKwhInput] = useState(0);
  let [consumptions, setConsumption] = useState([]);
  let [errorFetchingCosts, setErrorFetchingCosts] = useState(false);

  useEffect(() => {
    getConsumptionCosts(+kwhInput)
      .then(setConsumption)
      .catch(() => setErrorFetchingCosts(true));
  }, [kwhInput]);

  return (
    <>
      <h1>Introduce your consumption in kwh</h1>
      <input
        className="kwh-input"
        type="number"
        onChange={(e) => setKwhInput(e.target.value)}
        placeholder="1000"
      />
      {!errorFetchingCosts && (
        <>
          <h1>Your annual costs results:</h1>
          {consumptions.map((c, i) => (
            <ConsumptionCostInfo consumption={c} key={i} />
          ))}
        </>
      )}
      {errorFetchingCosts && (
        <h1>There was an error while fetching your costs, please refresh the page and try again</h1>
      )}
    </>
  );
}

export default ConsumptionCosts;
