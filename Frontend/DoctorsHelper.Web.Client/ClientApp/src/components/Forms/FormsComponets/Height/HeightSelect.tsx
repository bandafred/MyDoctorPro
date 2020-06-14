import * as React from "react";
import { InputNumber } from "antd";

const HeightSelect = (props: {
  min: number;
  max: number;
  default: number;
  setAction: Function;
}) => {
  return (
    <>
      Рост в сантиметрах: &nbsp;
      <InputNumber
        min={props.min}
        max={props.max}
        defaultValue={props.default}
        onChange={(e) => props.setAction(e)}
      /> см.
    </>
  );
};
export default HeightSelect;
