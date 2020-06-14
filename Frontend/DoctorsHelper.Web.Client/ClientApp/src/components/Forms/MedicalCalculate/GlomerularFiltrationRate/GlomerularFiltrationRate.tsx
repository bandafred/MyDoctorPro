import * as React from "react";
import { Row, Col } from "antd";
import styles from "./GlomerularFiltrationRate.module.css";
import { useState } from "react";
import TitleCalculatorArray from "../../FormsComponets/TitleCalculator/TitleCalculatorArray";
import ResultMedCalcilate from "../../FormsComponets/ResultMedCalcilate/ResultMedCalcilate";
import { IResult } from "../../../../common/Interfaces";
import ButtonResult from "../../FormsComponets/ButtonResult/ButtonResult";
import { GlomerularFiltrationRateResponse } from "../../../../apiClient/apiClient";
import SexSelect from "../../FormsComponets/SexSelect/SexSelect";
import AgeSelect from "../../FormsComponets/AgeSelect/AgeSelect";
import WeightSelect from "../../FormsComponets/Weight/WeightSelect";
import HeightSelect from "../../FormsComponets/Height/HeightSelect";
import InputInt from "../../FormsComponets/InputInt/InputInt";
import {GlomerularFiltrationRateResult} from "./GlomerularFiltrationRateAction";

const GlomerularFiltrationRate = () => {
  let ageDefault = 40;
  let heightDefault = 170;
  let weightDefault = 70;
  let creatininDefault = 55;
  let def: IResult<GlomerularFiltrationRateResponse> = {
    error: undefined,
    result: undefined
  };
  const [isMen, setIsMen] = useState(false);
  const [age, setAge] = useState(ageDefault);
  const [weight, setWeight] = useState(weightDefault);
  const [height, setHeight] = useState(heightDefault);
  const [creatinin, setCreatinin] = useState(creatininDefault);

  const [result, setResult] = useState(def);
  const [isLoad, setIsLoad] = useState(false);

  const calcing = async () => {
    setIsLoad(true);
    setResult(await GlomerularFiltrationRateResult(creatinin, age, weight, height, isMen));
    setIsLoad(false);
  };

  return (
    <Row className={styles.wrap}>
      <Col span={24}>
        <TitleCalculatorArray
          name={"Калькулятор скорости клубочковой фильтрации (СКФ) и клиренса креатинина"}
          description={[
            "Скорость клубочковой фильтрации (СКФ) – количество крови очищаемой почками за определенный период времени. СКФ является основным показателем для оценки функции почек и стадии почечной недостаточности. Скорость клубочковой фильтрации определяется по скорости очищения крови (клиренса) от определенных веществ, выводящихся почками, не подвергающихся секреции и реабсорбции в канальцах (чаще всего это креатинин, инулин, мочевина).Учитывая, что это достаточно трудоемкий способ, в клинической практике СКФ рассчитывается по специальным формулам на основе концентрации креатинина в крови и некоторых анатомо - физиологических показателей(рост, вес, возраст).Облегчает расчет использование специальных калькуляторов.Основные применяемые методики это формула Кокрофта - Голта, MDRD и уравнение CKD - EPI.",
            "Формула Кокрофта-Голта (Cockroft-Gault) - первая разработанная формула для оценки клиренса креатинина. Среди недостатков формулы можно выделить ее неточность при нормальных или незначительно сниженных значениях СКФ. ([140 – возраст в годах] * вес тела (кг) * (10,05 для женщин или 10,23 для мужчин))/креатинин плазмы (мкмоль/л)Формула MDRD более современная и в настоящее время широко используется, однако также имеет свои недостатки, в частности недооценивает СКФ на ее высоких уровнях.32788 * [креатинин плазмы (мкмоль/л)]^(-1.154) * возраст^(-0.203) * 0,742 (для женщин)Уравнение CKD-EPI, как правило, дает более точную оценку при СКФ > 60 мл/мин/1,73 м2."
          ]}
        />
      </Col>

      <Col xl={3}>
        <SexSelect setAction={setIsMen} />
      </Col>

      <Col xl={3}>
        <AgeSelect setAction={setAge} default={ageDefault} min={1} max={150} />
      </Col>

      <Col xl={5}>
        <WeightSelect
          setAction={setWeight}
          default={weightDefault}
          min={1}
          max={500}
        />
      </Col>

      <Col xl={5}>
        <HeightSelect
          setAction={setHeight}
          default={heightDefault}
          min={100}
          max={999}
        />
      </Col>

      <Col xl={6}>
        <InputInt
          default={creatininDefault}
          max={150}
          min={1}
          setAction={setCreatinin}
          preName={"Креатинин"}
          postName={"мкмоль/л"}
        />
      </Col>

      <Col xl={24}>
        <ButtonResult isLoad={isLoad} calcing={calcing} />
      </Col>

      <Col xl={24}>
        <ResultMedCalcilate result={result.result?.result} error={result.error} />
      </Col>
    </Row>
  );
};
export default GlomerularFiltrationRate;
