import * as React from "react";
import { Row, Col } from "antd";
import styles from "./HamviFormula.module.css";
import { useState } from "react";
import GenderSelect from "../../FormsComponets/GenderSelect/GenderSelect";
import TitleCalculator from "../../FormsComponets/TitleCalculator/TitleCalculator";
import { HamviFormulaResponse } from "../../../../apiClient/apiClient";
import Result from "../../FormsComponets/Result/Result";
import HeightSelect from "../../FormsComponets/Height/HeightSelect";
import ButtonResult from "../../FormsComponets/ButtonResult/ButtonResult";
import { IResult } from "../../../../common/Interfaces";
import {HamviFormulaCalculate} from "./Actions/HamviFormulaCalculate";


const HamviFormula = () => {
  let heightDefault = 141;

  let def: IResult<HamviFormulaResponse> = {
    error: undefined,
    result: undefined,
  };

  const [isMan, setIsMan] = useState(false);
  const [height, setHeight] = useState(heightDefault);
  const [result, setResult] = useState(def);
  const [isLoad, setIsLoad] = useState(false);

  const calcing = async () => {
    setIsLoad(true);
    setResult(await HamviFormulaCalculate(height, isMan));
    setIsLoad(false);
  };

  return (
    <Row className={styles.wrap}>
      <Col span={24}>
        <TitleCalculator
          name={"Формула Хамви"}
          description={
            "Формула Хамви появилась в 1964 году. Учитывает только рост и пол."
          }
        />
      </Col>

      <Col xl={3} className={styles.genderSelect}>
        <GenderSelect isMan={isMan} setIsMan={setIsMan} />
      </Col>

      <Col xl={11}>
        <HeightSelect
          setAction={setHeight}
          default={heightDefault}
          min={141}
          max={350}
        />
      </Col>

      <Col xl={24}>
        <ButtonResult isLoad={isLoad} calcing={calcing} />
      </Col>

      <Col xl={24}>
        <Result result={result.result?.result} error={result.error} />
      </Col>
    </Row>
  );
};
export default HamviFormula;
