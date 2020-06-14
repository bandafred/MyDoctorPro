import * as React from "react";
import { Row, Col } from "antd";
import styles from "./Score.module.css";
import { useState } from "react";
import TitleCalculatorArray from "../../FormsComponets/TitleCalculator/TitleCalculatorArray";
import ResultMedCalcilate from "../../FormsComponets/ResultMedCalcilate/ResultMedCalcilate";
import AgeSelect from "../../FormsComponets/AgeSelect/AgeSelect";
import SexSelect from "../../FormsComponets/SexSelect/SexSelect";
import { IResult } from "../../../../common/Interfaces";
import ButtonResult from "../../FormsComponets/ButtonResult/ButtonResult";
import { ScoreScaleResponse } from "../../../../apiClient/apiClient";
import SmokeSelected from "../../FormsComponets/SmokeSelected/SmokeSelected";
import Sad from '../../FormsComponets/Sad/Sad';
import CholesterolSelect from '../../FormsComponets/CholesterolSelect/CholesterolSelect';
import {ScoreResult} from "./ScoreScaleAction";

const Score = () => {
  let ageDefault = 40;
  let sadDefault = 120;
  let plasmaCholesterolDefault = 5.0;

  let def: IResult<ScoreScaleResponse> = {
    error: undefined,
    result: undefined
  };

  const [age, setAge] = useState(ageDefault);
  const [sad, setSad] = useState(sadDefault);
  const [plasmaCholesterol, setPlasmaCholesterol] = useState(plasmaCholesterolDefault);
  const [isMen, setIsMen] = useState(false);
  const [isSmoke, setIsSmoke] = useState(false);

  const [result, setResult] = useState(def);
  const [isLoad, setIsLoad] = useState(false);

  const calcing = async () => {
    setIsLoad(true);
    setResult(await ScoreResult(age, sad, plasmaCholesterol, isMen, isSmoke));
    setIsLoad(false);
  };

  return (
    <Row className={styles.wrap}>
      <Col span={24}>
        <TitleCalculatorArray
          name={"SCORE"}
          description={[
            "Шкала SCORE (Systematic COronary Risk Evaluation) разработана для оценки риска смертельного сердечно-сосудистого заболевания в течение 10 лет. Основой для шкалы послужили данные когортных исследований, проведенных в 12 странах Европы (включая Россию), с общей численностью 205 178 человек.",
            "Для лиц молодого возраста (моложе 40 лет) определяется не абсолютный, а относительный суммарный СС риск с использованием другой шкалы. Расчеты производятся автоматически в зависимости от возраста."
          ]}
        />
      </Col>

      <Col xl={3}>
        <AgeSelect setAction={setAge} default={ageDefault} min={1} max={150} />
      </Col>

      <Col xl={3}>
        <SexSelect setAction={setIsMen} />
      </Col>

      <Col xl={3}>
        <SmokeSelected setAction={setIsSmoke} />
      </Col>

      <Col xl={5}>
      <Sad
          setAction={setSad}
          default={sadDefault}
          min={60}
          max={300}
        />
      </Col>

      <Col xl={6}>
      <CholesterolSelect
          setAction={setPlasmaCholesterol}
          default={plasmaCholesterolDefault}
          min={1.0}
          max={30.0}
        />
      </Col>


      <Col xl={24}>
        <ButtonResult isLoad={isLoad} calcing={calcing} />
      </Col>

      <Col xl={24}>
        <ResultMedCalcilate result={result.result?.result} error={result.error} level={result.result?.level}/>
      </Col>
    </Row>
  );
};
export default Score;
