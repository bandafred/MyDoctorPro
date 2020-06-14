import * as React from "react";
import { Row, Col } from "antd";
import styles from "./IndexSolovieva.module.css";
import { useState } from "react";
import GenderSelect from "../../FormsComponets/GenderSelect/GenderSelect";
import WristLengthSelect from "../../FormsComponets/WristLengthSelect/WristLengthSelect";
import TitleCalculator from "../../FormsComponets/TitleCalculator/TitleCalculator";
import { IndexSolovievaResponse } from "../../../../apiClient/apiClient";
import Result from "../../FormsComponets/Result/Result";
import { IResult } from "../../../../common/Interfaces";
import ButtonResult from "../../FormsComponets/ButtonResult/ButtonResult";
import {IndexSolovievaCalculate} from "./Actions/IndexSolovievaCalculate";

const IndexSolovieva = () => {
  let wristLengthDefault = 4;

  let def: IResult<IndexSolovievaResponse> = {
    error: undefined,
    result: undefined,
  };
  const [isMan, setIsMan] = useState(false);
  const [wristLength, setWristLength] = useState(wristLengthDefault);

  const [result, setResult] = useState(def);
  const [isLoad, setIsLoad] = useState(false);

  const calcing = async () => {
    setIsLoad(true);
    setResult(await IndexSolovievaCalculate(isMan, wristLength));
    setIsLoad(false);
  };
  return (
    <Row className={styles.wrap}>
      <Col span={24}>
        <TitleCalculator
          name={"Индекс Соловьева"}
          description={
            "Измерить запястье в самом тонком месте. Именно так определяется объем кости, исходя из которого, известный медик Соловьев выводил понятие о трех типах телосложения: aстенический, нормостенический, гиперстенический."
          }
        />
      </Col>

      <Col xl={3} className={styles.genderSelect}>
        <GenderSelect isMan={isMan} setIsMan={setIsMan} />
      </Col>

      <Col xl={11}>
        <WristLengthSelect
          setWristLength={setWristLength}
          default={wristLengthDefault}
          min={4}
          max={500}
        />
      </Col>

      <Col xl={24}>
        <ButtonResult isLoad={isLoad} calcing={calcing} />
      </Col>

      <Col xl={24}>
        <Result result={result.result?.result} error={result.error}/>
      </Col>
    </Row>
  );
};
export default IndexSolovieva;
