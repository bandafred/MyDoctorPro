import * as React from "react";
import { Row, Col } from "antd";
import styles from "./IndexBrokaBruksha.module.css";
import { useState } from "react";
import TitleCalculator from "../../FormsComponets/TitleCalculator/TitleCalculator";
import { IndexBrokaBrukshaResponse } from "../../../../apiClient/apiClient";
import Result from "../../FormsComponets/Result/Result";
import HeightSelect from '../../FormsComponets/Height/HeightSelect';
import { IResult } from "../../../../common/Interfaces";
import ButtonResult from "../../FormsComponets/ButtonResult/ButtonResult";
import {IndexBrokaBrukshaCalculate} from "./Actions/IndexBrokaBrukshaCalculate";

const IndexBrokaBruksha = () => {
  let heightDefault = 121;
  let def: IResult<IndexBrokaBrukshaResponse> = {
    error: undefined,
    result: undefined,
  };

  const [height, setHeight] = useState(heightDefault);
  
  const [result, setResult] = useState(def);
  const [isLoad, setIsLoad] = useState(false);

  const calcing = async () => {
    setIsLoad(true);
    setResult(await IndexBrokaBrukshaCalculate(height));
    setIsLoad(false);
  };
  return (
    <Row className={styles.wrap}>
      <Col span={24}>
        <TitleCalculator
          name={"Индекс Брока-Бругша"}
          description={
            "Формула Брока-Бругша для определения идеального веса уточняет популярный индекс Брока, позволяет определить идеальный вес с учетом роста меньше 155 и больше 170 сантиметров."
          }
        />
      </Col>

      <Col xl={11}>
        <HeightSelect
          setAction={setHeight}
          default={heightDefault}
          min={121}
          max={300}
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
export default IndexBrokaBruksha;
