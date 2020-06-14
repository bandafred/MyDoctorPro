import * as React from "react";
import { InputNumber } from "antd";

const WeightSelect = (props: {
  min: number;
  max: number;
  default: number;
  setAction: Function;
}) => {
  return (
    <>
      Вес в килограммах: &nbsp;
      <InputNumber
        min={props.min}
        max={props.max}
        defaultValue={props.default}
        onChange={(e) => props.setAction(e)}
      /> кг.
    </>
  );
};
export default WeightSelect;
