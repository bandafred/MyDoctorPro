import * as React from "react";
import { Row, Col } from "antd";
import styles from "./EgorovaTable.module.css";
import { useState } from "react";
import GenderSelect from "../../FormsComponets/GenderSelect/GenderSelect";
import TitleCalculator from "../../FormsComponets/TitleCalculator/TitleCalculator";
import { EgorovaTableResponse } from "../../../../apiClient/apiClient";
import Result from "../../FormsComponets/Result/Result";
import HeightSelect from "../../FormsComponets/Height/HeightSelect";
import AgeSelect from "../../FormsComponets/AgeSelect/AgeSelect";
import ButtonResult from "../../FormsComponets/ButtonResult/ButtonResult";
import { IResult } from "../../../../common/Interfaces";
import {EgorovaTableCalculate} from "./Actions/EgorovaTableCalculate";


const EgorovaTable = () => {
  let heightDefault = 148;
  let ageDefault = 20;

  let def: IResult<EgorovaTableResponse> = {
    error: undefined,
    result: undefined,
  };

  const [isMan, setIsMan] = useState(false);
  const [height, setHeight] = useState(heightDefault);
  const [age, setAge] = useState(ageDefault);
  const [result, setResult] = useState(def);
  const [isLoad, setIsLoad] = useState(false);

  const calcing = async () => {
    setIsLoad(true);
    setResult(await EgorovaTableCalculate(height, isMan, age));
    setIsLoad(false);
  };

  return (
    <Row className={styles.wrap}>
      <Col span={24}>
        <TitleCalculator
          name={"Таблица Егорова-Левитского"}
          description={
            "Таблица Егорова-Левитского широко используется российскими диетологами. В таблице указан максимально допустимый вес."
          }
        />
      </Col>

      <Col xl={3} className={styles.genderSelect}>
        <GenderSelect isMan={isMan} setIsMan={setIsMan} />
      </Col>

      <Col xl={3}>
        <AgeSelect setAction={setAge} default={ageDefault} min={20} max={69} />
      </Col>

      <Col xl={11}>
        <HeightSelect
          setAction={setHeight}
          default={heightDefault}
          min={148}
          max={190}
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
export default EgorovaTable;
