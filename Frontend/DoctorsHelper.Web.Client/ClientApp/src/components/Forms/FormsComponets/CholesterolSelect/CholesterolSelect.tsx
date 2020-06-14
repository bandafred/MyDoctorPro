import * as React from "react";
import { InputNumber } from "antd";

const CholesterolSelect = (props: {
  min: number;
  max: number;
  default: number;
  setAction: Function;
}) => {
  return (
    <>
      Уровень холестерина: &nbsp;
      <InputNumber
        step={0.01}
        min={props.min}
        max={props.max}
        defaultValue={props.default}
        onChange={(e) => props.setAction(e)}
      /> ммоль/л.
    </>
  );
};
export default CholesterolSelect;
