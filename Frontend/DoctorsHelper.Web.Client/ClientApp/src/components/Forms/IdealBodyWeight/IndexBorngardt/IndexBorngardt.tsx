import * as React from "react";
import { Row, Col } from "antd";
import styles from "./IndexBorngardt.module.css";
import { useState } from "react";
import ChestСircumferenceSelect from "../../FormsComponets/ChestСircumferenceSelect/ChestСircumferenceSelect";
import TitleCalculator from "../../FormsComponets/TitleCalculator/TitleCalculator";
import { BorngardtResponse } from "../../../../apiClient/apiClient";
import Result from "../../FormsComponets/Result/Result";
import HeightSelect from '../../FormsComponets/Height/HeightSelect';
import { IResult } from "../../../../common/Interfaces";
import ButtonResult from "../../FormsComponets/ButtonResult/ButtonResult";
import {IndexBorngardtCalculate} from "./Actions/IndexBorngardtCalculate";

const IndexBorngardt = () => {
  let heightDefault = 121;
  let chestСircumferenceDefault = 31;
  
  let def: IResult<BorngardtResponse> = {
    error: undefined,
    result: undefined,
  };

  const [chestСircumference, setChestСircumference] = useState(chestСircumferenceDefault);
  const [height, setHeight] = useState(heightDefault);

  const [result, setResult] = useState(def);
  const [isLoad, setIsLoad] = useState(false);

  const calcing = async () => {
    setIsLoad(true);
    setResult(await IndexBorngardtCalculate(height, chestСircumference));
    setIsLoad(false);
  };

  return (
    <Row className={styles.wrap}>
      <Col span={24}>
        <TitleCalculator
          name={"Индекс Борнгардта"}
          description={
            'Индекс Борнгардта (1886 год) - единственный индекс, использующий окружность груди в формуле расчета идеального веса.'
          }
        />
      </Col>

      <Col xl={5} className={styles.genderSelect}>
        <ChestСircumferenceSelect
          setAction={setChestСircumference}
          default={chestСircumference}
          min={31}
          max={400}
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
        <Result result={result.result?.result}  error={result.error}/>
      </Col>
    </Row>
  );
};
export default IndexBorngardt;
