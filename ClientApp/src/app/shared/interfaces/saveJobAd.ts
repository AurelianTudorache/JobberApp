export interface SaveJobAd {
    id: number;
    name: string;
    locationId: number;
    skillId: number;
    posNeeded: number;
    description: string;
    requirments: string;    
    payRate: number;
    chargeRate: number;
    totalCharge: number;
    startDate: Date,
    endDate: Date,
    duration: number,
}