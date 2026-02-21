import { useState } from "react";
import { Animated, Pressable, StyleSheet, Text, View } from "react-native";
import { colors } from "../../theme/colors";
import AppCard from "../ui/AppCard";

const gyms = [
    { id: "1", name: "Hero Gym" },
    { id: "2", name: "Iron House" },
    { id: "3", name: "Titan Fitness" },
];

const TopGymsCarousel = () => {

    const [activeIndex, setActiveIndex] = useState(1);

    return ( 
        <View style={{ marginVertical: 20 }}>
            <Text
                style={{
                    fontSize: 18,
                    fontWeight: "700",
                    marginBottom: 16,
                    color: colors.primaryDark,
                }}
            >
                Top Gyms 
            </Text>

            <View 
                style={{
                    flexDirection: "row",
                    justifyContent: "space-between",
                }}
            >
                {gyms.map((gym, index) => {
                    const isActive = index === activeIndex;

                    return (
                        <Pressable
                            key={gym.id}
                            onPress={() => setActiveIndex(index)}
                        >
                            <Animated.View
                                // style = {[
                                //     {
                                //         width: isActive ? width * 0.5 : width * 0.22,
                                //         height: isActive ? 160 : 120,
                                //     },
                                // ]}
                            >
                                <AppCard>
                                    <text>
                                        {gym.name}
                                    </text>
                                </AppCard>
                            </Animated.View>
                        </Pressable>
                    )
                })}
            </View>
        </View>
     );
}
 
export default TopGymsCarousel;

const styles = StyleSheet.create({
    animated: {
    }
})