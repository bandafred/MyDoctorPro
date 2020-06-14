import * as React from "react";
import { Row, Col } from "antd";
import styles from "./Timi.module.css";
import { useState } from "react";
import TitleCalculatorArray from "../../FormsComponets/TitleCalculator/TitleCalculatorArray";
import ResultMedCalcilate from "../../FormsComponets/ResultMedCalcilate/ResultMedCalcilate";
import SwitchSelect from "../../FormsComponets/SwitchSelect/SwitchSelect";
import { IResult } from "../../../../common/Interfaces";
import ButtonResult from "../../FormsComponets/ButtonResult/ButtonResult";
import { TimiScaleResponse } from "../../../../apiClient/apiClient";
import {TimiResult} from "./TimiAction";

const Timi = () => {

  let def: IResult<TimiScaleResponse> = {
    error: undefined,
    result: undefined
  };

  const [oldAge, setOldAge] = useState(false);
  const [threeRisk, setThreeRisk] = useState(false);
  const [stenos, setStenos] = useState(false);
  const [liftSt, setLiftSt] = useState(false);
  const [stenocardia, setStenocardia] = useState(false);
  const [aspirin, setAspirin] = useState(false);
  const [necroze, setNecroze] = useState(false);

  const [result, setResult] = useState(def);
  const [isLoad, setIsLoad] = useState(false);

  const calcing = async () => {
    setIsLoad(true);
    setResult(await TimiResult(oldAge, threeRisk, stenos, liftSt, stenocardia, aspirin, necroze));
    setIsLoad(false);
  };

  return (
    <Row className={styles.wrap}>
      <Col span={24}>
        <TitleCalculatorArray
          name={"Шкала TIMI для оценки 2-недельного риска при остром инфаркте миокарда без подъема сегмента ST на ЭКГ"}
          description={[
            "Шкала TIMI основана на исследованиях TIMI IIВ и ESSENCE. Она учитывает возраст, клиническую картину, изменения ЭКГ и повышение уровня маркеров некроза миокарда. Она учитывает возраст, клиническую картину, изменения ЭКГ и повышение уровня маркеров некроза миокарда. Рассчитать индекс TIMI проще, так как учитываются только 6 показателей, однако по точности он уступает индексу GRACE.",
            "Примечание: факторы риска атеросклероза – семейный анамнез, АГ, СД, гиперхолестеринемия, курение. К больным высокого риска следует отнести тех, у кого сумма баллов по системе TIMI превышает 4. Высокий балл по шкале TIMI говорит о высоком риске смерти, инфаркта миокарда и повторной ишемии, требующей реваскуляризации. Шкала оценки риска TIMI менее точна в предсказании событий, чем шкала GRACE."
          ]}
        />
      </Col>

      <Col xl={12}>
       <SwitchSelect text={"Возраст более 65 лет"} setAction={setOldAge}/>
      </Col>
      <Col xl={12}>
       <SwitchSelect text={"Наличие трех и более факторов риска атеросклероза"} setAction={setThreeRisk}/>
      </Col>
      <Col xl={12}>
       <SwitchSelect text={"Ранее выявленный стеноз коронарной артерии более 50% диаметра"} setAction={setStenos}/>
      </Col>
      <Col xl={12}>
       <SwitchSelect text={"Подъем или депрессия сегмента ST на ЭКГ при поступлении"} setAction={setLiftSt}/>
      </Col>
      <Col xl={12}>
       <SwitchSelect text={"Два и более приступа стенокардии за последние 24 часа"} setAction={setStenocardia}/>
      </Col>
      <Col xl={12}>
       <SwitchSelect text={"Прием аспирина в течение последних 7 суток"} setAction={setAspirin}/>
      </Col>
      <Col xl={12}>
       <SwitchSelect text={"Повышение маркеров некроза миокарда"} setAction={setNecroze}/>
      </Col>

     

      <Col xl={24}>
        <ButtonResult isLoad={isLoad} calcing={calcing} />
      </Col>

      <Col xl={24}>
        <ResultMedCalcilate result={result.result?.result} error={result.error}/>
      </Col>
    </Row>
  );
};
export default Timi;
