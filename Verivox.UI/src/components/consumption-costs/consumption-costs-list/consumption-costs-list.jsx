import './consumption-costs-list.css';

function ConsumptionCostInfo({consumption}) {
  return <div className='consumption-card'>
    <h1>{consumption.name}</h1>
    <span>Cost: </span>
    <b>{consumption.annualCost} €</b>
  </div>;
}

export default ConsumptionCostInfo;
