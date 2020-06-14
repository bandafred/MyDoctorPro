import {KreffFormulaClient, KreffFormulaResponse} from '../../../../../apiClient/apiClient';
import {IErrors, IResult} from '../../../../../common/Interfaces';
import {getAuthClient} from "../../../../../apiClient/getAuthClient";

export async function KreffFormulaCalculate(
    height: number,
    age: number,
    lenCarpus: number
) {
    let res: IResult<KreffFormulaResponse> = {
        result: undefined,
        error: undefined,
    };

    try {
        let client = new KreffFormulaClient(getAuthClient());
        res.result = await client.calculate(height, age, lenCarpus);

        return res;

    } catch (error) {
        res.error = <IErrors>JSON.parse(error.response);
        return res;
    }
}