import * as React from "react";
import { Row, Col } from "antd";
import styles from "./IndexBroka.module.css";
import { useState } from "react";
import GenderSelect from "../../FormsComponets/GenderSelect/GenderSelect";
import TitleCalculator from "../../FormsComponets/TitleCalculator/TitleCalculator";
import { IndexBrokaResponse } from "../../../../apiClient/apiClient";
import Result from "../../FormsComponets/Result/Result";
import HeightSelect from '../../FormsComponets/Height/HeightSelect';
import { IResult } from "../../../../common/Interfaces";
import ButtonResult from "../../FormsComponets/ButtonResult/ButtonResult";
import {IndexBrokaCalculate} from "./Actions/IndexBrokaCalculate";

const IndexBroka = () => {
  let heightDefault = 156;

  let def: IResult<IndexBrokaResponse> = {
    error: undefined,
    result: undefined,
  };

  const [isMan, setIsMan] = useState(false);
  const [height, setHeight] = useState(heightDefault);

  const [result, setResult] = useState(def);
  const [isLoad, setIsLoad] = useState(false);

  const calcing = async () => {
    setIsLoad(true);
    setResult(await IndexBrokaCalculate(height, isMan));
    setIsLoad(false);
  };
  return (
    <Row className={styles.wrap}>
      <Col span={24}>
        <TitleCalculator
          name={"Индекс Брока"}
          description={
            "Формула для определения идеального веса была разработана в 1871 году французским хирургом и антропологом Полем Брока. Формула подходит для людей выше 155 и ниже 185 сантиметров среднего телосложения. Это уточненное определение для первой его известной формулы (рост минус 100)."
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
          min={156}
          max={184}
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
export default IndexBroka;
